   M S B A M L   `   `   `  ����J  FWpfApplication1, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null1clr-namespace:WpfApplication1WpfApplication1  5   	       WpfApplication1.MainWin   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   /localclr-namespace:WpfApplication1     5   	     � DataContext$  MainWindowViewModel��5   	    � Title$  Baronieverwaltung für DSA��5	   	   $
��1000��6+   $
��1500��69    � WindowStartupLocation$ CenterScreen=�5
   	    � WindowStyle$ ThreeDBorderWindow=�5   	   .��5      ]� .+�5   
   o� $	��Top=�6   .@�5      m� $��_Datei��6   .@�5      m� $
��_Neu��6   m� 5      $��_Öffnen��6   m� 5      $��
_Speichern��6    m� Command 6/   �� *	SaveCmd+�� 5      m� 5      $��_Exit��6    6*   �� *	ExitCmd+5      m� 5      $��_Nächster Monat��6    60   �� *NaechsterMonatCmd+m� 5      $��_Über��6   .@�5      m� $&�� Aventurische Boten 158+159kaufen��6    6E   �� *
BuyBoteCmd+5      5      � 5   
    � ColumnDefinitions 5      �� 5      $
��100* �6#   �� 5      $
��400* �6#   .+�5!      �  5"      �� 5#      $
��104* �6'   �� 5$      $	��14* �6'   �� 5%      $��6* �6'   �� 5&      $
��125* �6'    � RowDefinitions 5(      �� 5)      $
��Auto �6$   �� 5*      $
��Auto �6$   �� 5+      $
��Auto �6$   �� 5,      $
��Auto �6$   �� 5-      $
��Auto �6$   �� 5.      $
��Auto �6$   �� 5/      $
��Auto �6$   �� 50      $
��Auto �6$   �� 51      $
��Auto �6$   �� 52      $
��Auto �6$   �� 53      $
��Auto �6$   �� 54      $
��Auto �6$   .+�57      �� -   5         ��Name$ 	labelName��57   %   $��0��6   $
��Left=�6�   $	��Top=�6�   ��68   �� *DieBaronie.MyConfig.NameLabel+ �� UpdateSourceTrigger$ PropertyChanged=�6�   �� 58      $��0��6   $��3��6%   ��65   �� *DieBaronie.Name+$ PropertyChanged=��� 5;      $��1��6   $��Aktueller Monat:��6%   $
��Left=�6@   $	��Top=�6[   �� 5<      $��1��6   $��3��6%   ��65   �� *!DieBaronie.AktuellerMonatString+$ PropertyChanged=��� 5?      $��2��6   $
��Left=�6�   $	��Top=�6�   ��6%   �� *&$DieBaronie.MyConfig.GeldbestandLabel+$ PropertyChanged=�6�   �� 5@      $��2��6   $��3��6%   ��65   �� *" DieBaronie.SchatzKammerInDukaten+$ PropertyChanged=�	 � ContextMenu	 5A      �� 5B      .@�5C      m� $��Hinzufügen/Entfernen��6'    6E   �� *ChangeMoneyCmd+5D      5E      5G      �� 5J      $��3��6   $
��Left=�6�   $	��Top=�6�   ��6%   �� *+)DieBaronie.MyConfig.AnzBeschäftigteLabel+$ PropertyChanged=�6�   �� 5K      $��3��6   $��3��6%   ��65   �� *DieBaronie.AnzahlEinwohner+$ PropertyChanged=��� 5N      $��4��6   $
��Left=�6�   $	��Top=�6�   ��6&   �� *%#DieBaronie.MyConfig.LoyalitätLabel+$ PropertyChanged=�6�   �� 5O      $��4��6   $��3��6%   ��65   �� *DieBaronie.Loyalitaet+$ PropertyChanged=��� 5Q      $��5��6   $
��Left=�6}   $	��Top=�6�   ��6%   �� * DieBaronie.MyConfig.MoralLabel+$ PropertyChanged=�6�   �� 5R      $��5��6   $��3��6%   ��65   �� *DieBaronie.Moral+$ PropertyChanged=��� 5T      $��6��6   $
��Left=�6z   $	��Top=�6�   ��6%   �� *DieBaronie.MyConfig.SoLabel+$ PropertyChanged=�6�   �� 5U      $��6��6   $��3��6%   ��65   �� *DieBaronie.SoDesBarons+$ PropertyChanged=��� 5W      $��7��6   $��4��6)   $��Angestellte��6=   .��5X      �� $	��200��6   ��6,   �� *Angestellte+$ PropertyChanged=�
 �� SelectedIndex
 6u   �� *SelectedAngestellterIndex+	 5Y      �� 5Z      .@�5[   "   m� $��Funktion zuweisen��6+   .@�5\   &   m� $��Feste��6/    6>   �� *FunktionFesteCmd+m� 5]   &   $��Armenspeisung��6/    6F   �� *FunktionArmenspeisungCmd+m� 5^   &   $��Investitionen��6/    6F   �� *FunktionInvestitionenCmd+m� 5_   &   $��Korrespondenz��6/    6F   �� *FunktionKorrespondenzCmd+m� 5`   &   $��Sonderabgabe��6/    6E   �� *FunktionSonderabgabeCmd+m� 5a   &   $��Empfang��6/    6@   �� *FunktionEmpfangCmd+m� 5b   &   $��Abkommen��6/    6A   �� *FunktionAbkommenCmd+m� 5c   &   $��
Warenschau��6/    6C   �� *FunktionWarenschauCmd+5d   #   m� 5e   "   $��Hinzufügen��6+    6?   �� *AngestellterAddCmd+�� 5f   "   m� 5g   "   $��Löschen��6+    6<   �� *AngestellterRemoveCmd+5h      5j      5k      �� 5m      $��8��6   $��4��6)   ��6=   �� *+)DieBaronie.MyConfig.GroupboxSöldnerLabel+$ PropertyChanged=�.��5n      �� $	��125��6   
 6,   �� *SelectedSoeldnerBannerIndex+��6b   �� *DieBaronie.SöldnerEinheiten+	 5o      �� 5p      .@�5q   "   m� $��Hinzufügen��6+    6?   �� *SöldnerAddCmd+�� 5r   "   m� 5s   "   $��Löschen��6+    6<   �� *SöldnerRemoveCmd+5t      5v      5w      �� 5y      $��9��6   $��4��6)   ��6=   �� *,*DieBaronie.MyConfig.GroupboxGardistenLabel+$ PropertyChanged=�.��5z      �� $	��125��6   ��6,   �� *DieBaronie.Gardisten+
 6Y   �� *SelectedGardistenIndex+	 5{      �� 5|      .@�5}   "   m� $��Hinzufügen��6+    6?   �� *GardistAddCmd+�� 5~   "   m� 5   "   $��Löschen��6+    6<   �� *GardistRemoveCmd+5�      5�      5�      �� 5�      $��10��6   $��4��6*   $��Nachbarn��6>   .��5�      �� $	��125��6   ��6,   �� *
Nachbarn+
 6M   �� *SelectedNachbarIndex+	 5�      �� 5�      .@�5�   "   m� $��Hinzufügen��6+    6?   �� *NachbarAddCmd+�� 5�   "   m� 5�   "   $��Löschen��6+    6<   �� *NachbarRemoveCmd+5�      5�      5�      5�      �� 5�      $��1��6   ��6'   �� *-+DieBaronie.MyConfig.GroupboxEreignisseLabel+$ PropertyChanged=�.��5�      &   System.Windows.Controls.DataGrid     
IsReadOnly .    CanUserAddRows .  ��6   �� *DieBaronie.Ereignisse+5�      5�      5�      5�      5�      