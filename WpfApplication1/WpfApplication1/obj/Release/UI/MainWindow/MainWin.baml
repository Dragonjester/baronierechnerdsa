   M S B A M L   `   `   `  ���� J  FWpfApplication1, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null1clr-namespace:WpfApplication1WpfApplication1      WpfApplication1.MainWin   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     /localclr-namespace:WpfApplication1       � DataContext$  MainWindowViewModel�� � Title$  Baronieverwaltung für DSA��$
��1000��$
��1500�� � WindowStartupLocation$ CenterScreen=� � WindowStyle$ ThreeDBorderWindow=�.��]� .+�o� $	��Top=�.@�m� $��_Datei��.@�m� $
��_Neu��m� $��_Öffnen��m� $��
_Speichern�� m� Command �� *	SaveCmd+�� m� $��_Exit��m� $��_Nächster Monat�� �� *NaechsterMonatCmd+m� $��_Über���  � ColumnDefinitions �� $
��100* ��� $
��500* �.+��  �� $
��104* ��� $	��14* ��� $��6* ��� $
��125* � � RowDefinitions �� $
��Auto ��� $
��Auto ��� $
��Auto ��� $
��Auto ��� $
��Auto ��� $
��Auto ��� $
��Auto ��� $
��Auto ��� $
��Auto ��� $
��Auto ��� $
��Auto �.+��� -    ��Name$ 	labelName��$��0��$
��Left=�$	��Top=����� *DieBaronie.MyConfig.NameLabel+ �� UpdateSourceTrigger$ PropertyChanged=��� $��0��$��3������ *DieBaronie.Name+$ PropertyChanged=��� $��1��$��Aktueller Monat:��$
��Left=�$	��Top=��� $��1��$��3������ *!DieBaronie.AktuellerMonatString+$ PropertyChanged=��� $��2��$
��Left=�$	��Top=����� *&$DieBaronie.MyConfig.GeldbestandLabel+$ PropertyChanged=��� $��2��$��3������ *" DieBaronie.SchatzKammerInDukaten+$ PropertyChanged=��� $��3��$
��Left=�$	��Top=����� *+)DieBaronie.MyConfig.AnzBeschäftigteLabel+$ PropertyChanged=��� $��3��$��3������ *DieBaronie.AnzahlEinwohner+$ PropertyChanged=��� $��4��$
��Left=�$	��Top=����� *%#DieBaronie.MyConfig.LoyalitätLabel+$ PropertyChanged=��� $��4��$��3������ *DieBaronie.Loyalitaet+$ PropertyChanged=��� $��5��$
��Left=�$	��Top=����� * DieBaronie.MyConfig.MoralLabel+$ PropertyChanged=��� $��5��$��3������ *DieBaronie.Moral+$ PropertyChanged=��� $��6��$
��Left=�$	��Top=����� *DieBaronie.MyConfig.SoLabel+$ PropertyChanged=��� $��6��$��3������ *DieBaronie.SoDesBarons+$ PropertyChanged=��� $��7��$��4��$��Angestellte��.���� $	��200������ *DieBaronie.Angestellte+	 �� SelectedIndex	 �� *SelectedAngestellterIndex+
 � ContextMenu
 �� .@�m� $��Funktion zuweisen�� �� *AngestellterFunktionCmd+m� $��Hinzufügen�� �� *AngestellterAddCmd+�� m� $��Löschen�� �� *AngestellterRemoveCmd+�� $��8��$��4������ *+)DieBaronie.MyConfig.GroupboxSöldnerLabel+$ PropertyChanged=�.���� $	��125��	 �� *SelectedSoeldnerBannerIndex+���� *DieBaronie.SöldnerEinheiten+
 �� .@�m� $��Hinzufügen�� �� *SöldnerAddCmd+�� m� $��Löschen�� �� *SöldnerRemoveCmd+�� $��9��$��4������ *,*DieBaronie.MyConfig.GroupboxGardistenLabel+$ PropertyChanged=�.���� $	��125������ *DieBaronie.Gardisten+	 �� *SelectedGardistenIndex+�� $��1������ *-+DieBaronie.MyConfig.GroupboxEreignisseLabel+$ PropertyChanged=�.��&   System.Windows.Controls.DataGrid  ���� *DieBaronie.Ereignisse+