   M S B A M L   `   `   `  ����C  ?WPF_HW_3, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null#clr-namespace:WPF_HW_3WPF_HW_3  5   	       WPF_HW_3.AddProduct   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   (localclr-namespace:WPF_HW_3     5   	     � Title$  
AddProduct��5   	   $	��450��6   $	��300��6)   .��5	      � 
������� � RowDefinitions 5
   
   �� 5      6   �� 5      6   �� 5      $	��10* �6   6+   �� 5      6   .+�5   
   �� $
��Left=�6   $	��Top=�61   $��	10,10,0,0q�6I   $��20��6\   $	��100��6h   Enter Title:6�   �� 5   
   -   5         ��Name$ 	titleText��5      $��Right=�6%   $	��Top=�6A   $��	0,10,10,0q�6Y   $��20��6l   $	��200��6x   
�������6�   �� 5   
   $��1��6   $
��Left=�6"   $	��Top=�6=   $��	10,10,0,0q�6U   $��20��6h   $	��100��6t   Enter Price:6�   �� 5   
   -   5        $ price��5       �� 	MaxLength$ 6��6L   $��1��6Z   $��Right=�6g   $	��Top=�6�   $��	0,10,10,0q�6�   $��20��6�   $	��200��6�   
�������6�   �� 5   
   $��2��6   $
��Left=�6!   $	��Top=�6<   $��	10,10,0,0q�6T   $��20��6g   $	��100��6s   Enter Description:6�   �� 5   
   -   5        $ description��5      $��2��6'   $��Stretch=�64   $��Stretch=�6R   $��0,40,0,0q�6n   
�������6�   �� 5   
   -   5        $��3��5   &   $��Confirm��63   
�������6^   5      5      