   M S B A M L   `   `   `  ����F  BWPFAerodrom, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null5clr-namespace:WPFAerodrom.FormeWPFAerodrom.Forme  5   	   !    WPFAerodrom.Forme.FormKarta   5   	   W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   1localclr-namespace:WPFAerodrom.Forme     5   	     � Title$  	FormKarta��5   	   $	��400��6   $	��300��6(   .��5	      � .+�5
   
   �� $��Ime putnika:��6   $
��Left=�6'   $��	11,30,0,0q�6B   $	��Top=�6U   �� 5   
   $��
Tip karte:��6   $
��Left=�6%   $��	11,90,0,0q�6@   $	��Top=�6S   �� 5   
   $��ID leta:��6   $
��Left=�6#   $��
11,150,0,0q�6>   $	��Top=�6R   �� 5   
   $��Cena karte:��6   $
��Left=�6&   $��
11,210,0,0q�6A   $	��Top=�6U   �� 5   
   $��Broj sedista:��6   $
��Left=�6(   $��
11,270,0,0q�6C   $	��Top=�6W   �� 5   
   -   5         ��Name$ cbImePutnika��5      $
��Left=�6)   $��
100,32,0,0q�6D   $	��Top=�6X   $	��120��6p    �� DisplayMemberPath$	 ime��6|    �� SelectedValuePath$ putnikID��6�   �� 5   
   -   5        $ 
cbTipKarte��5      $
��Left=�6'   $��
100,92,0,0q�6B   $	��Top=�6V   $	��120��6n   $ klasa��6z   $ 
tipKarteID��6�   �� 5   
   -   5        $ cbLet��5      $
��Left=�6"   $��100,152,0,0q�6=   $	��Top=�6R   $	��120��6j   $ letID��6v   $ letID��6�   �� 5   
   -   5         ��Name$ txtCena��5      $
��Left=�6#   $��100,210,0,0q�6>   $��23��6S    �� TextWrapping$
 Wrap=�6`   $�� ��6t   $	��Top=�6|   $	��120��6�   �� 5   
   -   5        $ 
txtSediste��5      $
��Left=�6&   $��100,270,0,0q�6A   $��23��6V   $
 Wrap=�6c   $�� ��6w   $	��Top=�6   $	��120��6�   �� 5   
   -   5         ��Name$ btnOK��5      $��OK��6    $
��Left=�6-   $��
32,330,0,0q�6H   $	��Top=�6\   $��75��6t   6   �� 5   
   -   5        $ 	btnCancel��5      $��Cancel��6$   $
��Left=�65   $��177,330,0,0q�6P   $	��Top=�6e   $��75��6}   6�   5      5      