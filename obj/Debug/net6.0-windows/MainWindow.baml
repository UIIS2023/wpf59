   M S B A M L   `   `   `  ����F  BWPFAerodrom, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null)clr-namespace:WPFAerodromWPFAerodrom  5   	       WPFAerodrom.MainWindow   5   	   W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   +localclr-namespace:WPFAerodrom     5   	     � Title$  Aerodrom��5   	   $	��600��6   $
��1100��6'   .��5	      � 
�����_�.+�5
   
   &   System.Windows.Controls.DataGrid  -   5        $��dataGridCentralni��5
      $��Center=�6,   $��Center=�6I   $
��auto��6d   $
��auto��6r      
IsReadOnly$
 True��6      AlternatingRowBackground
 �����   CanUserAddRows$ False��5   ,      SelectionUnit$ FullRow=�6C      SelectionMode$ Single=�6[   �� 5   
   -   5         ��Name$ stackPanelTop��5      $��Center=�6,   $	��Top=�6I   $
��auto��6a    �� Orientation$ 
Horizontal=�6n   $��40��6�   .+�5      �� -   5         ��Name$ 	btnPutnik��5      $��Putnici��6(   $	��100��6:   6F   �� 5      -   5        $ btnPilot��5      $��Piloti��6'   $	��100��68   6D   �� 5      -   5        $ btnAvion��5      $��Avioni��6'   $	��100��68   6D   �� 5      -   5        $ btnStjuardesa��5      $��
Stjuardese��6,   $	��100��6A   6M   �� 5      -   5        $ btnKarta��5      $��Karte��6'   $	��100��67   6C   �� 5      -   5        $ btnTipKarte��5      $��Tipovi karte��6*   $	��100��6A   6M   �� 5      -	   5        $ btnAviokompanija��5      $��Aviokompanije��6/   $	��100��6G   6S   �� 5      -
   5        $ btnLet��5      $��Letovi��6%   $	��100��66   6B   5      �� 5   
   -   5        $ stackPanelBottom��5      $��Center=�6/   $��Bottom=�6L   $
��auto��6g   $ 
Horizontal=�6t   $��40��6�   .+�5      �� -   5        $ btnDodaj��5      $��Dodaj��6'   $	��250��67   6C   �� 5      -   5        $ 	btnIzmeni��5      $��Izmeni��6(   $	��250��69   6E   �� 5      -   5        $ 	btnObrisi��5      $��Obriši��6(   $	��250��69   6E   5      5      5      