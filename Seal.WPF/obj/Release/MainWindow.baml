   M S B A M L   `   `   `  ���� I  ESeal2D.Control, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullG4clr-namespace:Seal2D.Control;assembly=Seal2D.ControlSeal2D.Control   Seal.WPF   Seal.WPF.MainWindow   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Eseal4clr-namespace:Seal2D.Control;assembly=Seal2D.Control     -     �Name$  _this�� � Title$ Seal2D�� �� EdgeMode$ Aliased=�$	��350��$	��525�����	#FFCFCFCF��.  � WindowState$ 	Maximized=� � Icon$ Images/app_icon.png�� � 	Resources    AeroToolbar �� 
TargetType �� Property �� Value	 �� 
TargetType
 J� SnapsToDevicePixels �� Orientation K� IsItemsHost �� Color  MyFocusVisual  AeroMenu  AeroMenuButton  AeroToolbarButton �� CornerRadius �� Padding �� Triggers P� Property P� Value �� 
TargetName��%@  &	        &	 �     &	 �     &	     &	 �    7  �� " c�.���  � �� �� "	 c�.R��� 
 . ���#A0AFC3$��0,0,0,1q�._��� $ 
Horizontal=� . ���� $ White���� .���  � �� �� �� " o�.���  � ��
 �������  � ��
 �   ���  � ��$ Center=���  � ��$ Stretch=��� " m�.���  � ��$	 Top=���  � ��$	 Top=���  � �� �� "	 m�.R�� 
�������.+��� #��z���� " ��.���  �@�OverridesDefaultStyle . ��  �@�FocusVisualStyle8   ��  � �� �� "	 ��.R�� $��myGrid��$��2q�.+��� $��Border2��
 . ���	#FFCFCFCF$��0q�._��� $��Border1��
 . $ 2��$ 6,0,6,0q�$��0q���Z� ._��� $��Center=� P�  �@J�IsMouseOver . . ��� $ myGrid�� � �� �� $ White���� $ Border1�� � ��$ 1q��� $ Border2�� � ��$ 1q��� $ Border1�� �@��Padding$ 4,0,4,0q�P�  � �� . . ��� $ myGrid�� � �� �� $ 	Gainsboro���� $ Border2�� � ��$ 0q��� $ Border1�� � ��$ 1q��� $ Border1�� � �� �#BAC9DB�� $ Border1�� �@��Padding$ 5,0,5,0q�P�  �@J�IsKeyboardFocused . . ��� $ Border2�� � ��$ 1q��� $ Border1�� � ��$ 1q��� $ Border1�� �@��Padding$ 4,0,4,0q�.���  � ColumnDefinitions �� $��* ��� $
��Auto ��� $��* � � RowDefinitions �� $
��Auto ��� $��* ��� $
��Auto ��� $��* ��� $
��Auto �.+��� $��2��$��1�����#A0AFC3$��1q�._�7  1System.Windows.Forms.Integration.WindowsFormsHost  -   $
��Host��$	��840��$	��480��   Child. !   Seal2D.Control.Seal2DCanvas  -   c� #��[  $��3��$��Stretch=�$��0��$	��Top=�$��30��.@��� #��[ ���� $ 
Horizontal=�.+��� $��Файл��� $��4,2,0,0q�$��Center=�$	��Top=� � Points# �   @KL ��-  z ��[ @KL 
���   ��� $��20���� #��[ ���� 
 . $��16��$��16��$��Images/undo.png���� #��[ ���� 
 . $��16��$��16��$��Images/redo.png���� $��20���� #��[ ���� 
 . $��16��$��16��$��Images/cut.png���� #��[ ���� $��16��$��16��$��Images/page_copy.png���� #��[ ���� $��16��
 . $��16��$��Images/page_paste.png���� $��20���� #��[ ���� 
 . $��16��$��16��$��Images/draw_line.png���� #��[ ���� 
 . $��16��$��16��$��Images/draw_wave.png���� #��[ ���� $��16��$��16��$��Images/draw_ellipse.png���� #��[ ���� $ 
Horizontal=�.+��� 
 . $��16��$��16��$��Images/draw_polygon.png��� $��4,2,0,0q�$��Center=�$	��Top=�# �   @KL ��-  z ��[ @KL 
���   ��� #��[ ���� 
 . $��16��$��16��$"��Images/draw_calligraphic.png���� $��20���� #��[ ���� 
 . $��16��$��16��$��Images/border_color.png���� #��[ ���� 
 . $��16��$��16��$��Images/fill_color.png���� #��[ ���� 
 . $��16��$��16��$.��(Images/smartart_change_color_gallery.png��o� #��[ .@�m� $
��Menu��#��[ .@�m� #��[ $��	MenuItem1���� $��3��$��4��$��Stretch=�$��25��$��Bottom=�
�������.@��� ����  �� ElementName$ _this�� �� Path$ mouseX��� $��,���� ���� $ _this��$ mouseY��� $��пкс��