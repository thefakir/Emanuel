   M S B A M L   `   `   `  ����X  TXceed.Wpf.Toolkit, Version=2.5.0.0, Culture=neutral, PublicKeyToken=3e4669d2f30244f4P:clr-namespace:Xceed.Wpf.Toolkit;assembly=Xceed.Wpf.ToolkitXceed.Wpf.Toolkit  5       Emanuel   Emanuel.EventForm   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      NwpfTool:clr-namespace:Xceed.Wpf.Toolkit;assembly=Xceed.Wpf.Toolkit     5      .��5	      � .+�5
   
   �� $��Formulario de evento
��6   $��Center=�69   $��136,10,106,0q�6V   $	��Top=�6l   $	��234��6�   $��20(�6�   $
��Bold"�6�   �� 5   
   -   5        $��btbGoToMainWindow��5      $��Ir a la ventana principal��6*   $
��Left=�6N   $��
10,501,0,0q�6i   $	��Top=�6}   $	��143��6�   6�   �� 5   
   -   5        $��lblTitle��5      $��
Titulo(*):��6    $��Center=�65   $��145,83,394,0q�6R   $	��Top=�6h   $
��Bold"�6�   �� 5   
   -   5        $��txtTitle��5      $��Center=�6"   $��23��6?   $��229,83,142,0q�6K     �� TextWrapping$
  Wrap=�6a   $	��Top=�6u   $	��229��6�   �� 5   
   -   5         ��Name$ lblEventType��5      $��Tipo de evento(*):��6&   $��Center=�6C   $��94,114,394,0q�6`   $	��Top=�6v   $
��Bold"�6�   �� 5   
   -   5        $��cbMeetingType��5      $��Center=�6)   $��229,113,142,0q�6F   $	��Top=�6]   $	��229��6u   �� 5   
   -   5        $ lblDescription��5      $��Descripcion del evento:��6(   $��Center=�6J   $��64,140,394,0q�6g   $	��Top=�6}   $
��Bold"�6�   �� 5   
   -   5         ��Name$ txtDescription��5      $��Center=�6,   $	��129��6I   $��229,146,142,0q�6V   $
  Wrap=�6m   $	��Top=�6�   $	��229��6�   �� 5   
   -   5        $ lblstartEventDate��5      $#��Fecha de inicio de evento(*):��6+   $��Center=�6S   $��36,280,394,228q�6p   $	��Top=�6�   $
��Bold"�6�   �� 5   
   -	   5        $ lblstartEventTime��5      $"��Hora de inicio de evento(*):��6+   $��Center=�6R   $��40,322,394,0q�6o   $	��Top=�6�   $
��Bold"�6�   (  "System.Windows.Controls.DatePicker  5   
   -
   5        $��dpstarMeetingTime��5      $��Center=�6.   $��229,282,142,228q�6K   $	��Top=�6d   $	��229��6|   �� 5   
   -   5        $ lblEndEventDate��5      $#��Fecha de Cierre de evento(*):��6)   $��Center=�6Q   $��33,360,394,0q�6n   $	��Top=�6�   $
��Bold"�6�   �� 5   
   -   5        $ lblEndEventTim��5      $"��Hora de cierre de evento(*):��6(   $��Center=�6O   $��39,395,394,0q�6l   $	��Top=�6�   $
��Bold"�6�     5   
   -   5        $��dpEndMeetingTime��5      $��Center=�6-   $��229,362,142,0q�6J   $	��Top=�6a   $	��229��6y   "   Xceed.Wpf.Toolkit.TimePicker  5   
   -   5        $��	tpEndTime��5      $��229,399,142,0q�6.   $	��Top=�6E   $	��229��6]   $��Center=�6i     5   
   -   5        $��
tpStarTime��5      $��229,322,142,0q�6/   $	��Top=�6F   $	��229��6^   $��Center=�6j   �� 5   
   -   5        $��Guardar��5      $��Center=�6#   $��278,453,247,0q�6@   $	��Top=�6W   $��75��6o   $
��Bold"�6z   6�   5      5      