   M S B A M L   `   `   `  ����T  PNeigbourhoodManagementWPF, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullE'clr-namespace:NeigbourhoodManagementWPFNeigbourhoodManagementWPF  5   	   ,    &NeigbourhoodManagementWPF.SecondWindow   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   9local'clr-namespace:NeigbourhoodManagementWPF     5   	     � Title$  SecondWindow��5   	   $	��450��6   $	��800��6+   .��5	      � $��0,0,0,-6q�6    � ColumnDefinitions 5
   
   �� 5      $
��399* �6   �� 5      $
��401* �6   .+�5   
   �� $��Complaint Form��6   $
��Left=�6)   $��70��6D   $��
218,41,0,0q�6P   $	��Top=�6d   $��48(�6|   $	��364��6�   $��2��6�   �� 5   
   $
��Name��6   $
��Left=�6   $��
10,139,0,0q�6:   $	��Top=�6N   $��20(�6f   $��0��6t   $��37��6�   $��63��6�    J� RenderTransformOrigin$ 0.879,1.475&�6�   �� 5   
   -   5         ��Name$
 Name��5      $
��Left=�6    $��202,152,0,0q�6;    �� TextWrapping$
 Wrap=�6P   $�� ��6d   $	��Top=�6l   $	��169��6�   $��28��6�   $��0��6�   �� 5   
   $��Building Number��6   $
��Left=�6*   $��
10,170,0,0q�6E   $	��Top=�6Y   $��20(�6q   $��0��6   $��37��6�   $	��160��6�   �� 5   
   -   5        $ BuildingNumber��5      $
��Left=�6*   $��202,180,0,0q�6E   $
 Wrap=�6Z   $�� ��6n   $	��Top=�6v   $	��168��6�   $��28��6�   $��0��6�   �� 5   
   $��Apartment Number��6   $
��Left=�6+   $��
10,204,0,0q�6F   $	��Top=�6Z   $��20(�6r   $��0��6�   $��36��6�   $	��183��6�   �� 5   
   -   5        $ ApartmentNumber��5      $
��Left=�6+   $��202,208,0,0q�6F   $
 Wrap=�6[   $�� ��6o   $	��Top=�6w   $	��169��6�   $��28��6�   $��0��6�   �� 5   
   $#��Where did the incident occur?��6   $��Center=�68   $��	0,245,0,0q�6U   $	��Top=�6h   $��20(�6�   $��37��6�   $	��276��6�   �� 5   
   $��Building Number��6   $
��Left=�6*   $��
10,280,0,0q�6E   $	��Top=�6Y   $��20(�6q   $��0��6   $��37��6�   $	��160��6�   �� 5   
   -   5        $ ComplaintBuildingNumber��5      $
��Left=�63   $��202,288,0,0q�6N   $
 Wrap=�6c   $�� ��6w   $	��Top=�6   $	��169��6�   $��28��6�   $��0��6�   �� 5   
   $��Apartment Number��6   $
��Left=�6+   $��
10,312,0,0q�6F   $	��Top=�6Z   $��20(�6r   $��0��6�   $��38��6�   $	��183��6�   �� 5   
   -   5        $ ComplaintApartmentNumber��5      $
��Left=�64   $��202,317,0,0q�6O   $
 Wrap=�6d   $�� ��6x   $	��Top=�6�   $	��169��6�   $��28��6�   $��0��6�   �� 5!   
   $��Describe the issue��6   $
��Left=�6-   $��
10,137,0,0q�6H   $	��Top=�6\   $��20(�6t   $��1��6�   $��37��6�   $	��169��6�   �� 5"   
   -   5        $ Description��5"      $
��Left=�6'   $��
10,174,0,0q�6B   $
 Wrap=�6V   $�� ��6j   $	��Top=�6r   $	��368��6�   $��62��6�   $��1��6�   �� 5#   
   -   5         ��Name$ LabelComplaint��5#      $��Complaint Category��6(   $
��Left=�6E   $��	1,280,0,0q�6`   $	��Top=�6s   $��20(�6�   $��38��6�   $	��186��6�   $��1��6�   �� 5$   
   -   5         ��Name$ ComplaintCategory��5$      $
��Left=�6.   $��228,280,0,0q�6I   $	��Top=�6^   $	��150��6v   $��38��6�   $��1��6�   6�   �� 5%   
   -	   5        $��Submit��5%      $
��Left=�6"   $��228,345,0,0q�6=   $	��Top=�6R   $��50��6j   $	��150��6v   $��24(�6�   $��1��6�   5&      5'      