   M S B A M L   `   `   `  ����I  ERC_GUI_WATS.UI, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullE'clr-namespace:RC_GUI_WATS.UI.ViewModelsRC_GUI_WATS.UI.ViewModels  5      A%clr-namespace:RC_GUI_WATS.Core.ModelsRC_GUI_WATS.Core.Models  5      '    !RC_GUI_WATS.UI.Views.MessagesView   5      W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      6vm'clr-namespace:RC_GUI_WATS.UI.ViewModels     5      8models%clr-namespace:RC_GUI_WATS.Core.Models     5      $
��Auto��5      $
��Auto��6     � DataContext  5      1   +RC_GUI_WATS.UI.ViewModels.MessagesViewModel  5      .��5      � $��10q�6	    � RowDefinitions 5      �� 5      $
��Auto �6   �� 5      $��2* �6   �� 5      $��2* �6   �� 5      $��* �6   .+�5      �� $��Capital and Limits��6   $��0��6+   $��0,0,0,10q�68   .��5      ��  �� Orientation$ 
Horizontal=�6   .+�5   
   �� $
��10,0q�6   .+�5      �� $��Open Capital:��6   $��SemiBold"�6+   �� 5      ��6   �� *OpenCapital+ �� StringFormat$ {0:C}��5      �� 5   
   $
��10,0q�6   .+�5      �� $��Accrued Capital:��6   $��SemiBold"�6.   �� 5      ��6   �� *AccruedCapital+$ {0:C}��5      �� 5   
   $
��10,0q�6   .+�5      �� $��Total Capital:��6   $��SemiBold"�6,   �� 5       ��6   �� *TotalCapital+$ {0:C}��5!      �� 5"   
   $
��10,0q�6   .+�5#      �� $��Used Messages:��6   $��SemiBold"�6,   �� 5$      ��6   �� *UsedMessages+$
 {0}%��5%      �� 5&   
   $
��10,0q�6   .+�5'      �� $��Used Capital:��6   $��SemiBold"�6+   �� 5(      ��6   �� *UsedCapital+$
 {0}%��5)      5*   	   5+      �� 5.      $��CCG Messages��6   $��1��6%   $��0,0,0,10q�62   .��5/      &   System.Windows.Controls.DataGrid     AutoGenerateColumns$ False��50         
IsReadOnly$
 True��51       %� IsVirtualizing$
 True��52      ��5/      �� *CcgMessages+   Columns 53   
   0  *System.Windows.Controls.DataGridTextColumn  54      ,  &System.Windows.Controls.DataGridColumn   Header$ #��6   	   Width5  /System.Windows.Controls.DataGridLengthConverter$	 50 6P   1  +System.Windows.Controls.DataGridBoundColumn
   Binding
 6-   �� *SequenceNumber+6P     55      $
 Time��6   $		 150 6P   
 6-   �� *	Timestamp+6P     56      $
 Type��6   $		 120 6P   
 6-   �� *Type+6P     57      $ Content��6   $	 * 6P   
 60   �� *	Content+6P   59   	   5:      �� 5=      $��
Order Book��6   $��2��6#   $��0,0,0,10q�60   .��5>        $ False��5?      $
 True��5@      $
 True��5A      ��5>      �� *	OrderBook+ 5B   
     5C      $ ClOrdID��6   $		 150 6S   
 63   �� *	ClOrdID+6S     5D      $
 Time��6   $		 150 6T   
 63   �� *TransactTime+6T     5E      $
 Side��6   $	 60 6S   
 63   �� *Side+6S     5F      $ Symbol��6   $		 100 6S   
 63   �� *Symbol+6S     5G      $ Price��6   $	 80 6S   
 63   �� *Price+6S     5H      $	 Qty��6   $	 80 6S   
 63   �� *
OrderQty+6S     5I      $
 Text��6   $	 * 6S   
 63   �� *Text+6S   5K   	   5L      �� 5O      $��Active Instruments��6   $��3��6+   .��5P        $ False��5Q      $
 True��5R      $
 True��5S      ��5P      �� *ActiveInstruments+ 5T   
     5U      $
 ISIN��6   $		 150 6N   
 61   �� *ISIN+6N     5V      $ Ticker��6   $		 100 6N   
 61   �� *Symbol+6N     5W      $
 Name��6   $	 * 6N   
 61   �� *Name+6N     5X      $	 Net��6   $	 80 6N   
 61   �� *Net+6N     5Y      $ OpenLong��6   $	 80 6N   
 61   �� *
OpenLong+6N     5Z      $ 	OpenShort��6   $	 80 6P   
 62   �� *	OpenShort+6P   5\   	   5]      5^      5_      