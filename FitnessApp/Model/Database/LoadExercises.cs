using Model.Models;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Database
{
    public class LoadExercises
    {
        private readonly DatabaseService _databaseService;

        public LoadExercises(DatabaseService databaseService)
        {
            _databaseService = databaseService;
        }

        public async Task<List<Uebungen>> LoadUebungenAsync()
        {
            List<Uebungen> uebungenList = new List<Uebungen>();
            try
            {
                using (NpgsqlConnection connection = new NpgsqlConnection(_databaseService.BuildConnectionString()))
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
                // Hier können Sie die Fehlerbehandlung einfügen, z.B. Protokollierung oder Benachrichtigung
                Console.WriteLine("Fehler beim Laden der Übungen: " + ex.Message);
            }
            return uebungenList;
        }
    }
}
