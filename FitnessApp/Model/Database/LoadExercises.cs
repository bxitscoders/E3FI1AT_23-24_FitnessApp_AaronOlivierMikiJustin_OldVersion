using Model.Models;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Model.Database
{
    public class LoadExercises
    {
        public DatabaseService _databaseService;

        public LoadExercises()
        {
        }

        public LoadExercises(DatabaseService databaseService)
        {
            _databaseService = databaseService;
        }

        public async Task<List<Uebungen>> LoadUebungenAsync()
        {
            List<Uebungen> uebungenList = new List<Uebungen>();
            try
            {
                string connectionString = _databaseService.BuildConnectionString();
                using (NpgsqlConnection connection = new NpgsqlConnection(connectionString))
                {
                    await connection.OpenAsync();
                    string sql = "SELECT u.uebung_id, u.uebungname, m.muskel_id, m.muskel_name " +
                                 "FROM uebungen u " +
                                 "JOIN muskel m ON u.muskel_id = m.muskel_id;";
                    using (NpgsqlCommand command = new NpgsqlCommand(sql, connection))
                    using (NpgsqlDataReader reader = await command.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            int uebungenId = reader.GetInt32(0);
                            Uebungen existingExercise = uebungenList.FirstOrDefault(ex => ex.uebung_id == uebungenId);
                            if (existingExercise == null)
                            {
                                Uebungen uebung = new Uebungen()
                                {
                                    uebung_id = uebungenId,
                                    uebungname = reader.GetString(1),
                                    Muskeln = new List<Muskel>()
                                };
                                Muskel muskel = new Muskel()
                                {
                                    muskel_id = reader.GetInt32(2),
                                    muskel_name = reader.GetString(3)
                                };
                                uebung.Muskeln.Add(muskel);
                                uebungenList.Add(uebung);
                            }
                            else
                            {
                                Muskel muskel = new Muskel
                                {
                                    muskel_id = reader.GetInt32(2),
                                    muskel_name = reader.GetString(3)
                                };
                                existingExercise.Muskeln.Add(muskel);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Fehler beim Laden der Daten: {ex.Message}");
            }
            return uebungenList;
        }
    }
}
