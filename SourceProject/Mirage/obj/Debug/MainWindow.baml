   M S B A M L   `   `   `  ����A  =Mirage, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:MirageMirage  5   	   U QMahApps.Metro, Version=1.4.0.42, Culture=neutral, PublicKeyToken=f4fb5a3c4d1e5b4fV;clr-namespace:MahApps.Metro.Controls;assembly=MahApps.MetroMahApps.Metro.Controls 5	   	       Mirage.MainWindow   5      W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   &localclr-namespace:Mirage     5   	   PControls;clr-namespace:MahApps.Metro.Controls;assembly=MahApps.Metro     5	   	   U QMaterialDesignThemes.Wpf, Version=2.2.1.750, Culture=neutral, PublicKeyToken=nullFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5   	   -   5           AccentColorBrush(  "MahApps.Metro.Controls.MetroWindow    	GlowBrush#  �   5
   	     MaterialDesignBody#���  5   	   $��Regular"�5   	   $��13(�5   	   &   System.Windows.Media.TextOptions   TextFormattingMode$ Ideal=�5   	      TextRenderingMode$
 Auto=�5   	     MaterialDesignPaper#���  5   	     MaterialDesignFont#���  5   	    � Title$ Mirage Main��5   	   $	��591��6   $	��824��6*    � WindowStartupLocation$ CenterScreen=�6T   .��5      � $��0q�6   .+�5   
   (  "MaterialDesignThemes.Wpf.ColorZone     Mode$ PrimaryDark=�6#   $��16q�66   .��5      ]� .+�5      '  !MaterialDesignThemes.Wpf.PopupBox  $��Right=�6*      PlacementMode$ BottomAndAlignRightEdges=�6A      PopupContent. 5      �� .+�5      �� $��Mirage password manager��6!   {�.  6C   �� 5      $��version 1.0��6!   {�.  67   �� 5      �� 5       $��GitHub/JustMonk��6!   5!      5"      �� 5$       �� Orientation$ 
Horizontal=�6   +  %MaterialDesignThemes.Wpf.RippleAssist	   
IsCentered	 . .+�5'      d� -   5         $  MaterialDesignActionToggleButton#��[ 5'   #   
 � ToolTip$
 Anti-track protection��5(      $��37��6;   $��37��6F   ��5)      '  !MaterialDesignThemes.Wpf.PackIcon  5*      �  �ControlzEx.PackIconBase`1[[MaterialDesignThemes.Wpf.PackIconKind, MaterialDesignThemes.Wpf, Version=2.2.1.750, Culture=neutral, PublicKeyToken=null]]   Kind$ EyeOff=�66   1  +MaterialDesignThemes.Wpf.ToggleButtonAssist   	OnContent 5,        5-      $	 Eye=�66   5/      50      �� 52      $��Center=�6   $��Center=�69   $��22(�6T   �� 6c   $�Mirage password manager��6g   6�   53      54      �� 55   
   -   5         ��Name$ 
tabControl��55      $��10,84,10,36q�6)   $
��4,14q�6>   .@�56      �� $��All accounts��6   .��57      � $��0,0,0,-6q�6   .+�58      #	  MaterialDesignThemes.Wpf.Card	  +
  %MaterialDesignThemes.Wpf.ShadowAssist 
  ShadowDepth$ Depth2=�6*   $��32q�6[   $��Stretch=�6h   6�     59      $ EyeOff=�6.    J� Opacity$	 .56Q�6<   $��318,80,318,141q�6J   $
��Auto��6b   $
��Auto��6p   $��Stretch=�6}   $��Stretch=�6�   &   System.Windows.Controls.DataGrid  5;      -   5          Name$ account_grid��5;      $��0,0,0,53q�65      
IsReadOnly .    SelectionUnit$
 Cell=�6v     5=      $ PrimaryLight=�6/      CornerRadius$ 
0, 0, 2, 2��6C   $ Depth0=�6]   $��Bottom=�6�   $��48��6�   $��0q�6�   .��5?      �� 
�������$��30��64    �� CornerRadius$ 3��6C   $"
 Enter to search, ignore case��6T   $��	10,0,56,0q�6{   ._�5@      �  � ColumnDefinitions 5A   "   �� 5B   &   $
��Auto �67   �� 5C   &   $��* �67   .+�5E   "   �� -   5         ��Name$ SearchButton��5F   C     MaterialDesignToolButton#���  5E   )   $��24��5H   !   $��24��6-   ��5F   !   �� *SearchCommand+��5G   !   ��  �� ElementName$ 	SearchBox�� �� Path$
 Text�.��5I   &     $ Magnify=�6>   $	 .56Q�6M   5J   #   �� 5K   "   -   5         ��Name$ 	SearchBox��5L   F   $��1��5K   *   $��5 0 0 0q�6:   )  #MaterialDesignThemes.Wpf.HintAssist   Hint$ Search��5L      .  (MaterialDesignThemes.Wpf.TextFieldAssist   DecorationVisibility$ Hidden=�5M      $��0q�6[   $	��200��5N      $��Center=�6-   6H   �� 5P   "   -   5         * &MaterialDesignFloatingActionMiniButton#��[ 5P   )   $��0,-2,-45,-3q�5Q      $
 Reload table��5R      $��1��60   $��35��6@   $��Right=�6K   $��35��6g   $��Center=�6s   .��5S   &     $ Refresh=�6>   $��24��6M   $��24��6Y   5T   #   5V      5X      5Z      5\      5]      �� 5^      $��Add new��6   .��5_      � $��0,0,0,-6q�6   .+�5`      	  $ Depth2=�6*   $��32q�6[   $��Stretch=�6h   �� 5a      -   5        $ textbox_resourse��5a      $ Resourse��68    % !MaterialDesignFloatingHintTextBox#��[ 5b      $��
30,13,31,0q�6M   $��40��6a   $	��Top=�6m   $?
 9Resource linked with your account (example: facebook.com)��6�   �� 5c      -	   5        $ textbox_username��5c      $ Username��68   #��[ 5d      $��
30,58,31,0q�6Q   $��40��6e   $	��Top=�6q   $
 Username of your account��6�   �� 5e      -
   5        $ textbox_password��5e      $ Password��68   #��[ 5f      $��30,103,31,0q�6Q   $��40��6f   $	��Top=�6r   $
 Password of your account��6�   �� 5g      -   5        $ textbox_email��5g      $ Email��65   #��[ 5h      $��30,148,31,0q�6Q   $��40��6f   $	��Top=�6r   $;
 5Email of your account (like ex@mail.ru, ex@gmail.com)��6�   �� 5i      -   5        $ textbox_inform��5i      $ Information��66   #��[ 5j      $��30,193,31,0q�6Q   $��42��6f   $	��Top=�6r   $@
 :Any more information, may be registration date or anything��6�   �� 5k      -   5        $ textbox_type��5k      $
 Type��64   #��[ 5l      $��30,240,31,0q�6Q   $��40��6f   $	��Top=�6r   $:
 4Type of resourse (games, mail, social, money or any)��6�   �� 5m      -   5        $ button1��5m      $��Add new account��6.   $��
30,0,31,21q�6H   $��32��6r   $��Bottom=�6~   '  !MaterialDesignThemes.Wpf.Snackbar  5o      -   5          Name$ SnackbarThree��5p   .      MessageQueue 5o   .   4  .MaterialDesignThemes.Wpf.MessageQueueExtension  5p   .   5r      5s      �� 5t      $��	SQL-query��6   .��5u      � $��0,0,0,-6q�6   .+�5v      	  $ Depth2=�6*   $��32q�6[   $��Stretch=�6h     5x      $ PrimaryLight=�6/   $ 
0, 0, 2, 2��6C   $ Depth0=�6]   $	��Top=�6�   $��48��6�   $��0q�6�   .��5z      �� 
�������$��30��64   $ 3��6C   $
 Enter your sql-query��6T   $��
10,0,166,0q�6s   ._�5{      �  5|   "   �� 5}   &   $
��Auto �67   �� 5~   &   $��* �67   .+�5�   "   �� -   5        $ SearchButton2��5�   C   #���  5�   )   $��24��5�   !   $��24��6-   ��5�   !   �� *SearchCommand+��5�   !   �� $ 	SearchBox��$
 Text�.��5�   &     $ Magnify=�6>   $	 .56Q�6M   5�   #   �� 5�   "   -   5        $ textbox_sql��5�   S   $��1��5�   *   $��5 0 0 0q�6:   $ Enter the SQL-query��5�      $ Hidden=�5�      $��0q�6[   $	��200��5�      $��Center=�6-   �� 5�   "   -   5          MaterialDesignFlatButton#��[ 5�   )   $��
0,0,-155,0q�6[   $	��145��6o   $
 Execute this query��6{   $��1��6�   $��Right=�6�   ���	#A5FFFFFF$
��Auto��6�   .��6   Execute query5�   #   5�      5�      5�      �� 5�      -   5         ��Name$ 	textBlock��5�       $��10,60,10,26q�63   $
��Wrap=�6H   $��ExecuteNonQuery result��6\   5�      5�      �� 5�      $��	Edit mode��6   .��5�      � $��0,0,0,-6q�6   .+�5�      	  $ Depth2=�6*   $��32q�6[   $��Stretch=�6h     5�      $ EyeOff=�6.   $	 .56Q�6<   $��318,80,318,141q�6J   $
��Auto��6b   $
��Auto��6p   $��Stretch=�6}   $��Stretch=�6�     5�      -   5        $ edit_datagrid��5�      $��0,0,0,53q�6l   $
 Cell=�6~   ��66   �� 6~     5�      $ PrimaryLight=�6/   $ 
0, 0, 2, 2��6C   $ Depth0=�6]   $��Bottom=�6�   $��48��6�   $��0q�6�   .��5�      �� 
�������$��30��64   $ 3��6C   $"
 Enter to search, ignore case��6T   $��
10,0,236,0q�6{   ._�5�      �  5�   "   �� 5�   &   $
��Auto �67   �� 5�   &   $��* �67   .+�5�   "   �� -   5        $ SearchButton22��5�   C   #���  5�   )   $��24��5�   !   $��24��6-   ��5�   !   �� *SearchCommand+��5�   !   �� $ 	SearchBox��$
 Text�.��5�   &     $ Magnify=�6>   $	 .56Q�6M   5�   #   �� 5�   "   -   5        $ 
SearchBox2��5�   F   $��1��5�   *   $��5 0 0 0q�6:   $ Search��5�      $ Hidden=�5�      $��0q�6[   $	��200��5�      $��Center=�6-   6H   �� 5�   "   -   5        $ button3��5�   )   $��Save changes��6:   $��Right=�6Q   $��
0,0,-180,0q�6m   $	��Top=�6�   $	��170��6�   $��1��6�   $��30��6�   $
 Save your changes��6�   �� 5�   "   -   5        #��[ 5�   )   $��0,-2,-225,-3q�5�      $
 Reload table��5�      $��35��60   $��34��6;   $��Center=�6G   $��Right=�6y   $��1��6�   .��5�   &     $ Refresh=�6>   $��24��6M   $��24��6Y   5�   #   5�      5�      5�      5�      5�      5�      �� 5�   
   $��22��6   $��Bottom=�6!    	 PrimaryHueMidBrush#��� 	 6<   $��0,0,0,1q�6n   .+�5�      ]� .+�5�      �� -   5         ��Name$ label1��5�      $��1.0 release��6(     
 PrimaryHueMidForegroundBrush#��� 
 6>   $��12(�6z   $
��Left=�6�   $��5,0,0,0q�6�   � 5�      .+�5�        $ GithubCircle=�6.   $��Right=�6B   $��	0,4,130,4q�6^   #��� 
 6q   $��Center=�6�   �� 5�      -   5        $ label��5�      $��github.com/JustMonk��6+   #��� 
 6I   $��5,0,0,0q�6�   $��12(�6�   $��Right=�6�   $��0,0,5,0q�6�   5�      5�      5�      5�      5�      