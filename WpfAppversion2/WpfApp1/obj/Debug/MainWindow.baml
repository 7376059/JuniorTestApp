   M S B A M L   `   `   `  ����E  AJuniorTest, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null!clr-namespace:WpfApp1WpfApp1  5   	       WpfApp1.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   'localclr-namespace:WpfApp1     5   	     � Title$  
MainWindow��5   	   $	��639��6   $
��1066��6)    J� 	AllowDrop . .��5
      � -   5        $��
-2,10,2,-2q�5
       � ColumnDefinitions 5   
   �� 5      $��1* �6    � RowDefinitions 5   
   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      $
��243* �6   .+�5   
   �� -   5         ��Name$ 
Filebutton��5      $��Выбор файла��5      $
��Left=�5      $��10,5,0,0q�5      $	��Top=�5      $��92��5      $��20��5       J� RenderTransformOrigin$ 0.467,-0.35&�5      �� 5!   
   -   5         ��Name$ RichTextBox1��5!      $��Stretch=�5"      $��Stretch=�5#      " �� VerticalScrollBarVisibility$ Visible=�5$      $��1��5%      $ 	0.491,1.4&�5&       . $��0,35,0,0q�5,   &    �� IsUndoEnabled .  $��3��5-   C   	 � 	Resources	 5/      
 �� 
TargetType �� Property �� Value��%X   'J�       �� 50      "
 J�6   .�51      ��  �@��Margin$ 0q�6/   52      53      54      �� 56   
   -   5        $
 aply��56      $��Применить��57      $
��Left=�58      $��	10,11,0,0q�59      $��1��5:      $	��Top=�5;      $��92��5<      6   �� 5>   
   -   5         ��Name$ 	ComboBox1��5>      $
��Left=�5?      $��	214,0,0,0q�5@      $��Bottom=�5A      $��91��5B      .@�5C      �� -   5         ��Name$ Item1��5C       �� 
IsSelected . $ 	0.517,1.1&�6<   $��И��6^   �� 5D      -   5        $ testname��5D      $ 
0.528,-0.1&�6-   $��ИЛИ��6P   5E      �� 5G   
   -   5        $ 	ComboBox3��5G      $
��Left=�5H      $��214,11,0,35q�5I      $��1��5J      $��91��5K      $ 0.527,1.182&�6   .@�5L      �� -	   5        $��Item2��5L       . .��6:   И6=   �� 5M      -
   5        $��Item12��5M      .��6)   ИЛИ6.   5N      �� 5P   
   -   5         ��Name$ TextBox2��5P      $
��Left=�5Q      $��23��5R      $��	332,0,0,0q�5S       �� TextWrapping$
 Wrap=�5T      $	��Top=�5U      $	��120��5V      $ 	0.5,0.435&�6   �� 5X   
   -   5        $ TextBox4��5X      $
��Left=�5Y      $��23��5Z      $��
332,11,0,0q�6   $��1��5[      $
 Wrap=�6   $	��Top=�5\      $	��120��5]      �� 5_   
   -   5        $ 	ComboBox2��5_      $
��Left=�5`      $��	512,0,0,0q�5a      $	��Top=�5b      $��91��5c      $ 0.538,1.091&�6   .@�5d      �� -   5        $��Item3��5d       . .��6:   И6=   �� 5e      -   5        $��Item13��5e      .��6)   ИЛИ6.   5f      �� 5h   
   -   5        $ 	ComboBox4��5h      $
��Left=�5i      $��
512,0,0,35q�5j      $��1��6'   $��Bottom=�5k      $��91��5l      $ 0.626,0.727&�6   $��24��6B   .@�5m      �� -   5        $��Item4��5m       . .��6:   И6=   �� 5n      -   5        $��Item14��5n      .��6)   ИЛИ6.   5o      �� 5q   
   -   5        $ TextBox3��5q      $
��Left=�5r      $��23��5s      $��	630,2,0,0q�6   $
 Wrap=�5t      $	��Top=�5u      $	��120��5v      �� 5x   
   -   5        $ TextBox5��5x      $
��Left=�5y      $��23��5z      $��
630,11,0,0q�6   $��1��5{      $
 Wrap=�5|      $	��Top=�5}      $	��120��5~      $ 0.483,1.217&�6   5      5�      