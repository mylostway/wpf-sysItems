   M S B A M L   `   `   `  ����L  HWPFDataGridPaging, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null5clr-namespace:WPFDataGridPagingWPFDataGridPaging  5   	   "    WPFDataGridPaging.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   c _System.Windows.Interactivity, Version=4.5.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35Bi:http://schemas.microsoft.com/expression/2010/interactivity  5   	   +localclr-namespace:WPFDataGridPaging  5   	     � Title$  
MainWindow��5	   	   $	��350��6   $	��525��6)   .��5
      �  � RowDefinitions 5   
   �� 5      $��* �6   �� 5      $
��Auto �6   .+�5   
   &   System.Windows.Controls.DataGrid  $��0��6      AutoGenerateColumns .     CanUserAddRows .  ��6    �� *
FakeSource+   Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn   Header$ Item Id��6%      Width5  /System.Windows.Controls.DataGridLengthConverter$ 80 6M   1  +System.Windows.Controls.DataGridBoundColumn   Binding 66   �� *Id+6M     5      $ 	Item Name��6%   $	 180 6U    68   �� *
ItemName+6U   5         WPFDataGridPaging.Pagger  5-   
   $��Right=�6   $
��10,0q�63   $��1��6A      PageSize 5.      �� *
PageSize+	   	TotalPage	 64   �� *	TotalPage+
   CurrentPage
 6T   �� *CurrentPage+ �� Mode$ TwoWay=�.  (System.Windows.Interactivity.Interaction   Triggers 5/      /  )System.Windows.Interactivity.EventTrigger  50         	EventName$ 	FirstPage��6!   .	  (System.Windows.Interactivity.TriggerBase 	  Actions. 51      6
  0System.Windows.Interactivity.InvokeCommandAction
   
  Command 6,   �� *FirstPageCommand+52        53      $ PreviousPage��6!   . 54      
   6,   �� *PreviousPageCommand+55        56      $ NextPage��6!   . 57      
   6,   �� *NextPageCommand+58        59      $ LastPage��6!   . 5:      
   6,   �� *LastPageCommand+5;      5=      5>      5?      