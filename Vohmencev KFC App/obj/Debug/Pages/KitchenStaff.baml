   M S B A M L   `   `   `  ����L  HVohmencev KFC App, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullA%clr-namespace:Vohmencev_KFC_App.PagesVohmencev_KFC_App.Pages  5      *    $Vohmencev_KFC_App.Pages.KitchenStaff   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      7local%clr-namespace:Vohmencev_KFC_App.Pages     5        N� Title$  KitchenStaff��5	      .��5      �  � ShowGridLines .  
�������.+�5   
   �� $��0��6   
���  ��$��2��6/   �� 5   
   -   5         ��Name$ OrdersLabel��5      $��0��6%   $��0��62   $#��Очередь заказов��6B   $��Segoe UI Black)�6\   $��20(�6x   $
��Left=�6�   $��25,5,0,0q�6�   $	��Top=�6�   $	��200��6�   �� 5   
   -   5         ��Name$ 
OrdersList��5      $��1��6&   $��0��63   $��Segoe UI Black)�6C   $��24(�6_   $
��Left=�6m   $	��288��6�   $��	25,25,0,0q�6�   $	��Top=�6�   $	��345��6�   �� 5   
   -   5         ��Name$ OrdersStartButton��5      $��1��6,   $��0��69   $��Выбрать��6I   
�������$
��Left=�6n   $��125,335,0,0q�6�   $	��Top=�6�   $	��151��6�   $��50��6�   $��20(�6�   6�   �� 5   
   -   5        $ RecipeLabel��5      $��0��6%   $��1��62   $&�� Сейчас готовится:��6B   $��Segoe UI Black)�6^   $��20(�6z   $
��Left=�6�   $��25,5,0,0q�6�   $	��Top=�6�   $	��200��6�   �� 5   
   -   5        $ DishNameLabel��5      $��1��6'   $��1��64   $�� ��6D   $��Segoe UI Black)�6O   $��20(�6k   $
��Left=�6y   $��	25,10,0,0q�6�   $	��Top=�6�   $	��345��6�   �� 5   
   -   5        $ 
RecipeList��5      $��1��6&   $��1��63   $��Segoe UI Black)�6C   $��20(�6_   $
��Left=�6m   $	��253��6�   $��	25,60,0,0q�6�   $	��Top=�6�   $	��345��6�   �� 5   
   -   5        $ RemoveButton��5      $��1��6'   $��1��64   $��Отмена��6D   
���  ��$
��Left=�6g   $��
25,335,0,0q�6�   $	��Top=�6�   $	��159��6�   $��50��6�   $��20(�6�   6�   �� 5   
   -   5        $ ReadyButton��5      $��1��6&   $��1��63   $��Готово��6C   
���/���$
��Left=�6m   $��222,335,0,0q�6�   $	��Top=�6�   $	��148��6�   $��50��6�   $��20(�6�   6�    � ColumnDefinitions 5   
   �� 5      $��1* �6   6,   �� 5      $��1* �6   6,    � RowDefinitions 5   
   �� 5      $��50��6   �� 5      $	��350��6   5      5      