   M S B A M L   `   `   `  ����
  E-SiLK    E_SiLK.LevelOne   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   _ [Microsoft.Kinect.Toolkit, Version=1.8.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35h dMicrosoft.Kinect.Toolkit.Controls, Version=1.8.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e352k(http://schemas.microsoft.com/kinect/2013   5   	     � Title$  LevelOne��5   	   $	��768��6   $
��1024��6'    � WindowStartupLocation$ CenterScreen=�65    � DataContext 5   	   ��  �� RelativeSource �� *self+.��5      � ��5
   
   �� 5       �� ImageSource$  Images/Background/road.png��6   .+�5   
   �� .+�5      �� $	��100��6:   ��6   ��  �� Path$ MyProperty1�6:   5      �� 5   
   $
��Left=�6   $	��717��6,   $��0,10,-1056,0q�69   $	��Top=�6O   $
��2072��6g   .+�5      �� -   5        $
��busa��5   s   $	��192��6    �� Left$
 1007��6!   
 �� Top$	 499��64   $	��358��6E   $��Images/GameAsset/bus.png��6Q   6s   �� 5      -   5        $
��cara��5   s   $	��156��6   $
 1340��6!   $	 321��64   $	��280��6E   $��Images/GameAsset/car.png��6Q   6s   �� 5      -   5         ��Name$
 busb��5   s   $	��192��6   $
 1620��6!   $	 255��64   $	��358��6E   $��Images/GameAsset/bus.png��6Q   6s   �� 5      -   5        $
 carb��5   b   $	��156��6   $
 1620��6!   $	��280��64   $��Images/GameAsset/car.png��6@   6b   �� 5      -   5        $
 busc��5   r   $	��192��6   $
 1209��6!   $ 42��64   $	��358��6D   $��Images/GameAsset/bus.png��6P   6r   5      �� 5   
   $
��Left=�6   $	��767��6+   $��0,-18,0,-12q�68   $	��Top=�6M   $
��1016��6e   $%��Images/Background/layertree.png��6r   �� 5   
   .+�5      �� -   5        $��player��5   �   $	��126��6   $	 480��6!   $	 621��63   $	��152��6D   $!��Images/GameAsset/player.png��6P   	 J� RenderTransformOrigin$	 -0.51,2.012&�6u   6�   5      4  .Microsoft.Kinect.Toolkit.Controls.KinectRegion  5    
   -   5        $��kinectRegion��5       $��
0,110,-8,0q�6-   $	��627��6A   $	��Top=�6N   .��5!      � .+�5"      8  2Microsoft.Kinect.Toolkit.Controls.KinectTileButton  -   5        $
��Auto��5"   %   $��886,527,30,10q�63   $
��Auto��6J   ��5#      �� 5$      $! Images/Navigation/right.png��6%   6Q   5&        5(      -	   5        $
��Auto��5(   %   $��778,437,138,100q�63   $
��Auto��6L   ��5)      �� 5*      $# Images/Navigation/forward.png��6%   6S   5,        5.      -
   5        $
��Auto��5.   %   $��675,527,241,10q�63   $
��Auto��6K   ��5/      �� 50      $  Images/Navigation/left.png��6%   6P   52      53      55      � 59   
   $��	0,0,0,221q�6   .+�5:      4  .Microsoft.Kinect.Toolkit.KinectSensorChooserUI  -   5        $��sensorChooserUi��5:   [   $��Center=�6&   $	��Top=�6C   6[   8  2Microsoft.Kinect.Toolkit.Controls.KinectUserViewer  5;      $	��Top=�6!   $��Center=�69   $	��100��6�   
   UserColoringMode$
 Manual=�6�      KinectRegion 6V   ��  �� ElementName$ kinectRegion��6�   5<      5>      5?      