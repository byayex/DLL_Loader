   M S B A M L   `   `   `  ����E  ADLL_Loader, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null'clr-namespace:DLL_Loader
DLL_Loader  5   	       DLL_Loader.Loader   5   	   W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   *localclr-namespace:DLL_Loader     5   	     � Title$  Loader��5   	   $	��450��5	   	   $	��450��5
   	    � WindowStyle$
 None=�5   	    � 
ResizeMode$ NoResize=�5   	   ���#333333.��5      �  � RowDefinitions 5   
   �� 5      $��35 �6   �� 5      $��30 �6   �� 5      $��32 �6   �� 5      $��40 �6   �� 5      .+�5   
   �� -   5        
������ $��Right=�5      $��0q�5      $��Close��5      
����d�$��Arial Black)�5      $��25(�5      $��1q�5      5      �� 5    
   $-��'Please enter your 16 digit license key:��6   ���#679DFF$��15(�5"      $��Bottom=�5#      $��Arial Black)�5$      $��10,0,0,0q�5%      $��1��5&      �� 5'   
   $��2��6   .+�5(      ��  �� Orientation$ 
Horizontal=�6   .+�5)      �� -   5         ��Name$ txt_license��5)      $	��350��5*      ���#333333$��2q�5,      
����d�$��Arial Black)�5.      $��15(�5/       �� TextAlignment$ Center=�50      $��Center=�51      $��Center=�52       �� MaxLines$ 1��53       �� 	MaxLength$ 16��54      $��10,0,0,0q�55      $��30��56      $	��350��57      �� 58      -   5        	 ��Name$	 	redeem1bt��59      
������ $��Center=�5:      $��2q�5;      $��Redeem��5<      
����d�$��Arial Black)�5>      $��15(�5?      $��15,0,0,0q�5@      5A      5B      5C      �� 5D   
   $ 
Horizontal=�6   $��3��6.   $��Center=�6;   .+�5E      �� $��Time left: ��6   
����d�$��70,0,0,0q�5G      $��15(�5H      $��Arial Black)�5I      $��Center=�5J      �� 5K      -   5        
 ��Name$
 	time_left��5K      $��0 Days��5L      $��Center=�5M      $��Center=�5N      $��15(�5O      $��Arial Black)�5P      
���  ��5Q      5R      �� 5S   
   $��4��6   
�������$��1q�62   �� 5T   
   -   5         ��Name$ loaderstackpanel��5T   6   $��4��6   $y�Hidden=�6"   .+�5U      �� $$��Please select the GTA process:��6   
����d�$��15(�5V      $��Arial Black)�5W      $��Center=�5X      �� 5Y      -   5         ��Name$ 	processes��5Y      
����d�$��15(�5Z      $��Arial Black)�5[      
������ $��10q�5]      5^      �� 5_      -   5        
������ $��Center=�5`      $��2q�5a      $%��  Start the injection process  ��5b      
����d�$��Arial Black)�5d      $��15(�5e      $��0,20,0,0q�5f      5g      �� 5h      
����d�$��15(�5i      $��Arial Black)�5j      $��Center=�5k      $��0,30,0,0q�5l      .��5m      �� After pressing the button�� 5n      &$wait until this window closes itself�� 5o   :   �� 6F   .,If you cannot find GTA restart this software5p   ?   5q      5r      5s      5t      