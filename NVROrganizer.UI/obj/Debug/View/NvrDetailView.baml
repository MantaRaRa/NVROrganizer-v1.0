   M S B A M L   `   `   `  ����J  FNvrOrganizer.UI, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null;"clr-namespace:NvrOrganizer.UI.ViewNvrOrganizer.UI.View  5      (    "NvrOrganizer.UI.View.NvrDetailView   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      4local"clr-namespace:NvrOrganizer.UI.View     5      .��5
      �   � RowDefinitions  5   
   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      �� 5      $
��Auto �6   .+�5   
   �� $��
First Name��6   $��
10 10 10 0q�6%   �� 5   
   $��1��6   $��
10 0 10 10q�5   C   ��5      �� *Nvr.FirstName+ �� Mode$ TwoWay=� �� UpdateSourceTrigger$ PropertyChanged=�5   C   �� 5   
   $��2��6   $��	Last Name��6   $
��10 0q�61   �� 5   
   $��3��6   $��
10 0 10 10q�5   C   ��5      �� *Nvr.LastName+$ TwoWay=�$ PropertyChanged=�5   C   �� 5   
   $��4��6   $��NVR Info��6   $
��10 0q�60   �� 5   
   $��5��6   $��
10 0 10 10q�5    C   ��5      �� *Nvr.NvrInfo+$ TwoWay=�$ PropertyChanged=�5    C   �� 5"   
   $��7��6    �� Orientation$ 
Horizontal=�6"   .+�5#      �� $
��Save��6   $	��125��6$   $��10q�60   ��5$      �� *SaveCommand+�� 5%      $��Delete��6   $	��125��6&   $��10q�62   ��5&      �� *DeleteCommand+5(      5)      5*      