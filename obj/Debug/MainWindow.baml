   M S B A M L   `   `   `  ����C  ?Viewer3D, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null/clr-namespace:_3DModelViewer_3DModelViewer  5   	       Laba1.MainWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   .localclr-namespace:_3DModelViewer     5   	   -   5          � Title$  
MainWindow��5	   	   $	��658��6   $
��1103��6)   .��5
      � -   5        $��mainGrid��5
      ���	#FFEEEEEE$��0,0,2,0q�62   .+�5   
   �� $��aspect��6   $
��Left=�6!   $��	17,23,0,0q�6<   $	��Top=�6O   4  .System.Windows.Automation.AutomationProperties   Name$ cameraPosition��6g   �� 5   
   $	��FOV��6   $
��Left=�6   $��	66,23,0,0q�69   $	��Top=�6L   $ cameraPosition��6d   �� 5   
   $
��ZFar��6   $
��Left=�6   $��
118,23,0,0q�6:   $	��Top=�6N   $ cameraPosition��6f   �� 5   
   $��ZNear��6   $
��Left=�6    $��
170,23,0,0q�6;   $	��Top=�6O   $ cameraPosition��6g   �� 5   
   $��height��6   $
��Left=�6!   $��	62,86,0,0q�6<   $	��Top=�6O   $ cameraPosition��6g   �� 5   
   $��width��6   $
��Left=�6    $��	12,86,0,0q�6;   $	��Top=�6N   $ cameraPosition��6f   �� 5   
   $
��XMin��6   $
��Left=�6   $��
118,86,0,0q�6:   $	��Top=�6N   $ cameraPosition��6f   �� 5   
   $
��YMin��6   $
��Left=�6   $��
170,86,0,0q�6:   $	��Top=�6N   $ cameraPosition��6f   �� 5   
   -   5        $��cameraAspect��5   �   $
��Left=�6   $��23��6-   $��	14,54,0,0q�69    �� TextWrapping$
 Wrap=�6N   $	��Top=�6b   $��47��6z   $��1.333��6�   6�   �� 5   
   -   5        $��	cameraFOV��5   �   $
��Left=�6   $��23��6-   $��	66,54,0,0q�69   $
 Wrap=�6L   $	��Top=�6`   $��47��6x   $��90��6�   6�   �� 5   
   -   5        $��
cameraZFar��5   �   $
��Left=�6   $��23��6-   $��
118,54,0,0q�69   $
 Wrap=�6M   $	��Top=�6a   $��47��6y   $	��100��6�   6�   �� 5   
   -   5        $��cameraZNear��5   �   $
��Left=�6   $��23��6-   $��
170,54,0,0q�69   $
 Wrap=�6M   $	��Top=�6a   $��47��6y    J� RenderTransformOrigin$ 0.851,1.174&�6�   $	��0.2��6�   �� 5   
   -   5        $��
viewHeight��5   �   $
��Left=�6   $��23��6-   $��
66,117,0,0q�69   $
 Wrap=�6M   $	��Top=�6a   $��47��6y   $	��600��6�   6�   �� 5   
   -   5        $��	viewWidth��5   �   $
��Left=�6   $��23��6-   $��
14,117,0,0q�69   $
 Wrap=�6M   $	��Top=�6a   $��47��6y   $	��800��6�   6�   �� 5   
   -	   5        $��viewXMin��5   �   $
��Left=�6   $��23��6-   $��118,117,0,0q�69   $
 Wrap=�6N   $	��Top=�6b   $��47��6z   $��0��6�   6�   �� 5   
   -
   5        $��viewYMin��5   �   $
��Left=�6   $��23��6-   $��170,117,0,0q�69   $
 Wrap=�6N   $	��Top=�6b   $��47��6z   $��0��6�   6�   �� 5   
   -   5        $��	mainImage��5      $
��Left=�6!   $	��594��6<   $��
260,23,0,0q�6I   $	��Top=�6]   $	��823��6u   �� 5   
   -   5         ��Name$ 
LoadButton��5   $   
�������$
��Load��68   $
��Left=�6G   $��
10,592,0,0q�6b   $	��Top=�6v   $	��103��6�   $��22��6�   6�   5      5      