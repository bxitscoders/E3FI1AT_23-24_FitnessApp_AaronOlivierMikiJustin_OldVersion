   M S B A M L   `   `   `  ����E  AFitnessApp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null'clr-namespace:FitnessApp
FitnessApp  5   	   =#clr-namespace:FitnessApp.ViewModelsFitnessApp.ViewModels  5   	       FitnessApp.MainWindow   5   	   W SPresentationCore, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   *localclr-namespace:FitnessApp     5   	   9	viewModel#clr-namespace:FitnessApp.ViewModels     5   	     � Title$  FitnessTrainer��5	   	    � 
ResizeMode$ CanResizeWithGrip=�5
   	   
������  � AllowsTransparency$
 True��5   	    � WindowStyle$
 None=�5   	    � DataContext 5      )  #FitnessApp.ViewModels.MainViewModel  5   
   .��5      ��  �� CornerRadius$ 20��6   ���#272537._�5   
   � -   5         �Name$ 
LayoutRoot��5       � ColumnDefinitions 5      �� 5      $��* �6#   �� 5      $��4* �6#    � RowDefinitions 5      �� 5      $��* �6    �� 5      $��4* �6    .+�5       �� $��Hello,
'Name'��6   $��0��5!      $��0��5"      $��Center=�5#      $��Center=�5$      
�������$��24(�5&      $
��Bold"�5'      5(      �� 5)      -   5        $��0��5)      $��1��5*      $��X��5+      $��0q�5-      $��Right=�5.      $	��Top=�61   $��50��5/      $��30��50      ��51      �� 52      	 �� 
TargetType"	 ��6&   .R�53      �� 
���  ��#��z��54      #��z��55      $ 0,20,0,0��56      ._�57      �� $��Center=�6/   $��Center=�58   #   
�������$��18(�5:   #   5;      5<      5>      �� 5A      $��0��6   $��1��6)   .+�5B      	� -   5        $��Start Training��5B      $��50��5C      
�������$��14(�5E         MenuButtonTheme#��[  5F      ��5G      �� *TrainingViewCommand+6F   	� 5H      -   5        $��Progress��5H      $��50��5I      
�������$��14(�5K      #��[  5L      ��5M      �� *ProgressViewCommand+6F   	� 5N      -   5        $��Exercise Overview��5N      $��50��5O      
�������$��14(�5Q      #��[  5R      ��5S      �� *ExerciseOverviewViewCommand+6N   5T      �� 5V      $��1��6   $��1��5W      $��10q�5X      ��5Y      �� *CurrentView+5Z      5[      5]      