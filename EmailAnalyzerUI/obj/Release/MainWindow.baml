   M S B A M L   `   `   `  ���� J  FEmailAnalyzerUI, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null1clr-namespace:EmailAnalyzerUIEmailAnalyzerUI       EmailAnalyzerUI.MainWindow   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35U QWPFToolkit, Version=3.5.40128.1, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     /localclr-namespace:EmailAnalyzerUI     -     � Title$  
MainWindow��$��701.522��$��1398.508�� � 
ResizeMode$ CanMinimize=� � 	Resources    Storyboard1 g� RepeatBehavior g� 	BeginTime �� 
TargetName �� TargetProperty O� KeyTime O� Value��%�   &	        �� $ Forever��.��U� $ 00:00:00X�$ EllipseAnimate��$V P(UIElement.RenderTransform).(TransformGroup.Children)[2].(RotateTransform.Angle)�.\��� $ 00:00:02��$	 360Q�	 � Triggers	 :� 
 :� RoutedEvent$
 FrameworkElement.Loaded��.[��� #��[  .��� $��	0,0,14,-1q�.+��� $��Trend Analyzer��$
��Left=�$��
353,53,0,0q�$	��Top=�$	��585��$	��981��.���� -    ��Name$ 	MainPanel��
���   �$
��Auto=�$
��Auto=���. $	��559��$	��Top=�$��0,0,25,0q�.+�� -    �Name$ MainPanelGrid��$	��550�� � RowDefinitions �� $	��20* ��� $	��20* ��� $	��20* ��� $	��20* ��� $	��20* ��� $��Select days from now��$
��Left=�$��
10,321,0,0q�$	��Top=�$��27��$	��327�����	#FF462DE2$��14(�#��� ���� -    ��Name$ ComboBx_Days�� �� Text$ Select number of days��$
��Left=�$��
10,353,0,0q�$	��Top=�$	��327��$��34��.@��� 
 � Tag$ 7��$��7���� $ 15��$��15���� $ 30��$��30���� $ 60��$��60���� $ 90��$��90���� $	 120��$	��120���� $	 365��$	��365���� $��
Trend Type��$
��Left=�$��
10,392,0,0q�$	��Top=�$	��102��$	��327��$��18(�	� -    	�Name$ DepartmentAnalysis��$��Department Analysis�� 	� 	GroupName$ TrendsGroup��$
��Left=�$��
37,421,0,0q�$	��Top=�$��34��$	��300�� J� RenderTransformOrigin$ 0.561,-0.072&�$��18(�	� -   $ InterestAnalysis��$��People Analysis��$ TrendsGroup��$
��Left=�$��
37,460,0,0q�$	��Top=�$��34��$	��300��$ 0.561,-0.072&�$��18(��� -    ��Name$ 
Btn_Filter��$��Filter��$
��Left=�$��206,499,0,0q�$	��Top=�$	��131��$��34��$��16(�����  �� EndPoint$ 0.5,1&� �� 
StartPoint$ 0.5,0&�.���  � Color$ 	LightGray�� � Offset$ 0Q�� $ White��$ 1Q��� -    ��Name$ Email_Folders��$
��Left=�$	��198��$��	10,95,0,0q�$	��Top=�$	��327���� $
��Left=�$��15��
���   �$	��Top=�$
��1377������ $ 0.5,1&�$ 0.5,0&�.��� $ Azure��$ 0Q�� $ 	#FFDBD3F7��$ 0.523Q��� $��Microsoft Outlook��$
��Left=�$��0,15,0,0q�$	��Top=�$	��217��$��22(�$
��Bold"��� $ ��Discussion Thread Analyzer��$
��Left=�$��
206,16,0,0q�$	��Top=�$��40��$
��1171��$��22(����	#FFD84848��
�  
� GradientOrigin$ 8,0.5&�.��� $ Black��� $ White��$ 1Q�A� -	    A�Name$ EllipseAnimate�����	#FFF4F4F5$
��Left=�$��13��$��818,353,0,0q�$	��Top=�$��13��$y�Visible=�z�V� .~��� �� �� ���� $ 0.445,0.997&�$ 0.555,0.003&�.��� $ White��$ 0Q�� $ 	#FF0052FF��$ 1Q��� -
    ��Name$ LabelLoding��$��Loading ...��$
��Left=�$��792,392,0,0q�$	��Top=����	#FFF9F8F8$
��Bold"��� $4��.Select outlook folder that you want to analyze��$
��Left=�$��	10,68,0,0q�$	��Top=�$��27��$	��327�����	#FF462DE2$��14(�#��� ���� -   $ Btn_Setting��$��Setting��$
��Left=�$��
70,499,0,0q�$	��Top=�$	��131��$��34��$��16(����� $ 0.5,1&�$ 0.5,0&�.��� $ 	LightGray��$ 0Q�� $ White��$ 1Q�