   M S B A M L   `   `   `  ����J  FWpfApplication1, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullG(clr-namespace:WpfApplication1.UI.NachbarWpfApplication1.UI.Nachbar  5   	   -    'WpfApplication1.UI.Nachbar.NeuerNachbar   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   :local(clr-namespace:WpfApplication1.UI.Nachbar     5   	     � Title$  NeuerNachbar��5   	   $��156.268��6   $��262.395��6/   .��5	      �  � ColumnDefinitions 5
   
   �� 5      $
��Auto �6   �� 5      $
��Auto �6    � RowDefinitions 5   
   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   .+�5   
   �� $��Name der Baronie: ��6   $��0��6-   $��0��6:   �� 5   
   $��0��6   $��1��6    $��	1,0,-33,0q�6P   ��60   �� *NameDerBaronie+6P   �� 5   
   $��SO des Barones: ��6   $��1��6+   $��0��68   �� 5   
   $��1��6   $��1��6    $��	1,0,-33,0q�6N   ��60   �� *SoDerBaronie+6N   �� 5   
   $��Startbeziehungswert: ��6   $��2��60   $��0��6=   �� 5   
   $��2��6E   $��1��6R   $��	1,0,-33,0q�6b    �� SelectedIndex 6   �� *SelectedIndexBeziehung+.@�5      �� -   5        $
��cbi1��5      .��6'   
Verfeindet63   �� 5      -   5        $
��cbi2��5      .��6'   	Abgeneigt62   �� 5       -   5        $
��cbi3��5       .��6'   	Skeptisch62   �� 5!      -   5        $
��cbi4��5!      .��6'   	Neutral60   �� 5"      -   5        $
��cbi5��5"      .��6'   Offen6.   �� 5#      -   5        $
��cbi6��5#      .��6'   
Verbündet62   �� 5$      -   5        $
��cbi7��5$      .��6'   Freundschaftlich69   5%      �� 5&   
   -   5         ��Name$ button��5&      $��OK��6�   $��1��6�   $��3��6�   $	��Top=�6�   $��75��6�   $��	20,10,0,0q�6�   $��Center=�6�   {�6!   �� *IsOkayAllowed+ �� UpdateSourceTrigger$ PropertyChanged=���6j   �� *OkCmd+6�   �� 5'   
   -	   5        $ button1��5'      $��	Abbrechen��6@   $��0��6T   $��3��6e   $	��Top=�6r   $��75��6�   $��0,10,0,0q�6�   $��Center=�6�   ��6"   �� *	CancelCmd+6�   5)      5*      