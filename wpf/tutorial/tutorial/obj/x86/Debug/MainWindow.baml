   M S B A M L   `   `   `  ����C  ?tutorial, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null#clr-namespace:tutorialtutorial  5   	       tutorial.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   %myclr-namespace:tutorial     5   	     � Title$  
MainWindow��5   	   $	��300��6   $	��525��6)    � 	Resources 5         RootFolderDataProvider S� ObjectInstance   tutorial.Folder   FullPath �� DataType �� ItemsSource �� Path��%�   &	        (�� A     5      *, +)S� 5   
    5	        5
      $	 c:\��6   5      �� 5   
   "  5       5      �� $ 
SubFolders�.R�5      �� ��6   �� $
 Name�5      5      .��5      �  � ColumnDefinitions 5   
   �� 5      $��2* �6   �� 5      $��* �6    � RowDefinitions 5   
   �� 5      $��* �6   �� 5      $��* �6   .+�5   
   R� -   5        $��	treeView1��5   �   $��0��6   $��1��6#   $��2��67   $
��auto��6I   $��Stretch=�6W   $��0,0,0,0q�6u   $	��Top=�6�   $
��auto��6�   .@�5       Q� $��Folders��6s   ��6   �� $ 
SubFolders�	 �� Source#	 [  6s   5!      �� 5%   
   -   5        $��	listView1��5%   �   $��1��6   $��0��6#   $
��auto��6I   $��Stretch=�6W   $��0,0,0,0q�6u   $	��Top=�6�   $
��auto��6�   ��5&      �� $ SelectedItem.SubFolders�
 �� ElementName$
 	treeView1�� �� Mode$ OneWay=��� 5*   
   -   5        $��	listView2��5*   �   $��1��6   $��1��6#   $
��auto��6I   $��Stretch=�6W   $��0,0,0,0q�6u   $	��Top=�6�   $
��auto��6�   ��5+      �� $ SelectedItem.Files�$
 	treeView1��$ OneWay=��� 5.      $��2��6   $��5��6    $��Stretch=�6*   5/      50      