   M S B A M L   `   `   `  ���� E  AtestCsharp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null1clr-namespace:testCsharp.ViewtestCsharp.View  3clr-namespace:testCsharp.ModeltestCsharp.Model  =#clr-namespace:testCsharp.View.ThemetestCsharp.View.Theme  "    testCsharp.View.SettingsView   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008     /localclr-namespace:testCsharp.View     0modelclr-namespace:testCsharp.Model     5theme#clr-namespace:testCsharp.View.Theme       N� Title$  SettingsView��.��� 
���   � � RowDefinitions �� $��2* ��� $��8* ��� $��* � � 	Resources  �� 
TargetType �� Property#   testCsharp.View.Theme.Brushes   Primary �� Value   	Secondary    testCsharp.View.Theme.Font   
FontFamily	   SubTitle
   Title��%�  '��       '�� �     '�� �     �� " ��.���  � ��# Z ��  � ��# Z ��  � ��# Z ��  � ��# Z	 ��  � ��$
 10,5q���  � ��$	 0,5q��� " ��.���  � ��# Z ��  � ��# Z
 ��  � ��# Z �� " ��.���  � ��# Z ��  � ��# Z
 ��  � ��# Z ��  � ��
 ���� ��  � ��
 ���� ��  �@��
CaretBrush# Z .+�� $��0��$��Center=�$��Center=�.+���  �� Orientation$ 
Horizontal=�$��Center=�$��Center=�.+��� $��s��   Headline#��Z #��Z �� $��ettings��#��Z #��Z � $��1�� � ColumnDefinitions �� $��* ��� $��2* ��� $��* ��� $��2* ��� $��* �.+��� $��1��$ Vertical=�$��Right=�$��Center=�.+��� $��Player Name��$��Right=�#��Z $
��0,10q��� $��Number of Decks��$��Right=�#��Z $
��0,10q��� $��3��$ Vertical=�$
��Left=�$��Center=�.+��� -   $��PlayerNameInputBox��$��0, 10q� �� 	MaxLength$ 25������    testCsharp.Model.Settings   
PlayerName �� Source# Z  �� Path$ .��� -   $��NumberOfDecksInputBox��$��0, 10q�����    NumberOfDecks# Z $ .�� $��2�� �� $��* ��� $��4* ��� $��* �.+��� -   $��1��$��Save and Exit��   	SubHeader#��Z $��0, 20q�