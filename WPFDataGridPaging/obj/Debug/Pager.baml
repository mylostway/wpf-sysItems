   M S B A M L   `   `   `  ����L  HWPFDataGridPaging, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null5clr-namespace:WPFDataGridPagingWPFDataGridPaging  5          WPFDataGridPaging.Pager   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      1localclr-namespace:WPFDataGridPaging     5        � 	Resources  5	       �� 
TargetType �� Property �� Value��%  '��       '�� �     '�� r    �� 5
   
   " ��6   .�5      ��  � ��$ 22��6&   �� 5       � ��$ 22��6'   �� 5       � ��$	 3,0q�6'   �� 5       � ��$ Center=�62   5      �� 5   
   " ��6   .�5      ��  � ��$ 30��6&   �� 5       � ��$ 18��6'   �� 5       � ��$	 3,0q�6'   �� 5       � ��$ Center=�62   5      �� 5   
   " ��6   .�5      ��  � ��$	 3,0q�6'   �� 5       � ��$ Center=�62   5      5      .��5      � .+�5   
   ��  �� Orientation$ 
Horizontal=�6   $��1��6.   .+�5      �� -   5         ��Name$ FirstPageButton��5      $	��5,0q�6.   .��5      F� $��7��6   $��10��6!   =����        �    ��� �    @KL р�[ �� р�[  z �    @KL 	
���   �$��1��6^   
���   �$��Center=�6   $��Center=�6�   5      �� 5       -   5        $ PreviousPageButton��5       $��0,0,5,0q�61   .��5!      F� $��8��6   $��8��6!   "����     	= � z     � z  z 	
���   �
���   �$��Center=�6]   $��Center=�6x   5"      �� 5#      $��Center=�6   �� 5$      $	�第��6    �� 5%      -   5         ��Name$ rCurrent��5%      $�0��6(    �� 5&      $	�页��6   5'      �� 5(      -   5        $ NextPageButton��5(   "   $	��5,0q�6   .��5)      F� $��8��6   $��8��6!   "����     	= � z     � z  z 	
���   �
���   �$��Center=�6]   $��Center=�6x   z�5*      �� 5+       �� Angle$	 180Q�6*    �� CenterX$ 4Q�66   	 �� CenterY$	 4Q�6B   5-      5.      �� 5/      -   5        $ LastPageButton��5/   &   $��0,0,5,0q�6   .��50      F� -   5        
 F�Name$
 MainPath��50      $��7��6)   $��10��63   =����        �    ��� �    @KL р�[ �� р�[  z �    @KL 	
���   �$��1��6q   
���   �$��Center=�6�   $��Center=�6�   z�51      �� 52      $	 180Q�6*   $ 3Q�66   $	 5Q�6B   54      55      �� 56      $��Center=�6   �� 57      $	�共��6    �� 58      -   5        $ rTotal��58      $�0��6&    �� 59      $	�页��6   5:      5;      5<      5=      