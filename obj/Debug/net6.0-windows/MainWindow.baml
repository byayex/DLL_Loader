   M S B A M L   `   `   `  ����E  ADLL_Loader, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null'clr-namespace:DLL_Loader
DLL_Loader  5   	       DLL_Loader.MainWindow   5   	   W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   *localclr-namespace:DLL_Loader     5   	     � Title$  LoginWindow��5   	   $	��450��5	   	   $	��450��5
   	    � WindowStyle$
 None=�5   	    � 
ResizeMode$ NoResize=�5   	   ���#333333.��5      �  � RowDefinitions 5   
   �� 5      $��35 �6   �� 5      .+�5   
   �� -   5        
������ $��Right=�5      $��0q�5      $��Close��5      
����d�$��Arial Black)�5      $��25(�5      $��1q�5      5      �� 5   
   $��1��6   .+�5      �� $��Please log in��6   $��1��5      
����d�$��30(�5!      $��15q�5"      $��Arial Black)�5#      $��Center=�5$       J� BitmapEffect 5%      F� 5&       F� Color$ Black��6-    F� 	Direction$	 320Q�6;    F� ShadowDepth$ 10Q�6K    F� Opacity$ .5Q�6\   	 F� Softness$	 9Q�6i   5(      �� 5)      $��	Username:��6   ���#679DFF$��20(�5+      $��15q�5,      $��Arial Black)�5-      $��Center=�5.      �� 5/      -   5        
 ��Name$
 txt_username��5/      $	��350��50      ���#333333$��2q�52      
����d�$��Arial Black)�54      $��25(�55       �� MaxLines$ 1��56       �� 	MaxLength$ 40��57      $��30��58      �� 59      $��	Password:��6   ���#679DFF$��20(�5;      $��15q�5<      $��Arial Black)�5=      $��Center=�5>      G� 5?      -   5         G�Name$ txt_password��5@      $	��350��5A      ���#333333$��2q�5C      
����d�$��Arial Black)�5E      $��25(�5F       G� 	MaxLength$ 30��5G      $��30��5H      �� 5I      -   5        
������ $��Center=�5K      $��2q�5L      $��Login��5M      
����d�$��Arial Black)�5O      $��30(�5P      $��30q�5Q      5R      5S      5T      5U      