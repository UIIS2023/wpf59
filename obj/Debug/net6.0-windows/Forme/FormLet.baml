   M S B A M L   `   `   `  ����F  BWPFAerodrom, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null5clr-namespace:WPFAerodrom.FormeWPFAerodrom.Forme  5   	       WPFAerodrom.Forme.FormLet   5   	   W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   1localclr-namespace:WPFAerodrom.Forme     5   	     � Title$  FormLet��5   	   $	��550��6   $	��300��6&   .��5	      � .+�5
   
   �� $��Pilot:��6   $
��Left=�6!   $��	11,30,0,0q�6<   $	��Top=�6O   �� 5   
   $��Stjuardesa:��6   $
��Left=�6&   $��	11,90,0,0q�6A   $	��Top=�6T   �� 5   
   $��Avion:��6   $
��Left=�6!   $��
11,150,0,0q�6<   $	��Top=�6P   �� 5   
   $��Broj putnika:��6   $
��Left=�6(   $��
11,210,0,0q�6C   $	��Top=�6W   �� 5   
   $��Vreme polaska:��6   $
��Left=�6)   $��
11,270,0,0q�6D   $	��Top=�6X   �� 5   
   $��Vreme dolaska:��6   $
��Left=�6)   $��
11,330,0,0q�6D   $	��Top=�6X   �� 5   
   $��Destinacija:��6   $
��Left=�6'   $��
11,390,0,0q�6B   $	��Top=�6V   �� 5   
   -   5         ��Name$ cbImePilota��5      $
��Left=�6(   $��
100,32,0,0q�6C   $	��Top=�6W   $	��120��6o    �� DisplayMemberPath$	 ime��6{    �� SelectedValuePath$ pilotID��6�   �� 5   
   -   5        $ cbImeStjuardese��5      $
��Left=�6,   $��
100,92,0,0q�6G   $	��Top=�6[   $	��120��6s   $	 ime��6   $ stjuardesaID��6�   �� 5   
   -   5        $ cbAvion��5      $
��Left=�6$   $��100,152,0,0q�6?   $	��Top=�6T   $	��120��6l   $ model��6x   $ avionID��6�   �� 5   
   -   5         ��Name$ txtBrojPutnika��5      $
��Left=�6*   $��100,210,0,0q�6E   $��23��6Z    �� TextWrapping$
 Wrap=�6g   $�� ��6{   $	��Top=�6�   $	��120��6�   �� 5   
   -   5        $ txtvremePolaska��5      $
��Left=�6+   $��100,270,0,0q�6F   $��23��6[   $
 Wrap=�6h   $�� ��6|   $	��Top=�6�   $	��120��6�   �� 5   
   -   5        $ txtvremeDolaska��5      $
��Left=�6+   $��100,330,0,0q�6F   $��23��6[   $
 Wrap=�6h   $�� ��6|   $	��Top=�6�   $	��120��6�   �� 5   
   -   5        $ txtDestinacija��5      $
��Left=�6*   $��100,390,0,0q�6E   $��23��6Z   $
 Wrap=�6g   $�� ��6{   $	��Top=�6�   $	��120��6�   �� 5   
   -   5         ��Name$ btnOK��5      $��OK��6    $
��Left=�6-   $��
32,450,0,0q�6H   $	��Top=�6\   $��75��6t   6   �� 5   
   -	   5        $ 	btnCancel��5      $��Cancel��6$   $
��Left=�65   $��177,450,0,0q�6P   $	��Top=�6e   $��75��6}   6�   5      5      