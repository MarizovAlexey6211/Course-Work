   M S B A M L   `   `   `  ????I  ETextComparerMA, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null/clr-namespace:TextComparerMATextComparerMA  5   	       TextComparerMA.MainWindow   5   	   W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   .localclr-namespace:TextComparerMA     5   	   ] YXceed.Wpf.Toolkit.NET5, Version=4.5.0.0, Culture=neutral, PublicKeyToken=3e4669d2f30244f47toolkit)http://schemas.xceed.com/wpf/xaml/toolkit  64   $	??450??5   	   $	??800??5	   	     ? Title$  
MainWindow??5
   	   $	??650??6   $
??1200??6)   ???#36393F ? WindowStyle$
 None=?5   	   .??5      ? .+?5   
   ?  ? RowDefinitions 5      ?? 5      $??25 ?6    ?? 5      ?? 5      $??50 ?6     ? ColumnDefinitions 5      ?? 5      $??60 ?6#   ?? 5      $??* ?6#   ?? 5      $??60 ?6#   ?? 5      $??* ?6#   .+?5      ?? $??Text Comparer??6   $??0??6,   $??0??69   $??20(?6I   
????+??6W   ?? 5      $??0??6   $??4??6"   
???iii?._?5       ?? $??Text Comparer??6   $??0??60   $??0??6=   $??12(?6M   
???  ??6[   5!      ?? 5#      $??Right=?6    ?? Orientation$ 
Horizontal=?65   $??3??6N   .+?5$      ?? -   5        $??25??5$      $??25??6$   $
??🗕??5%   %   
?????? $??0q?5'   %   
???  ??$
??Bold"?5)   %   $??0,0,0,3q?5*   %   5+   %   ?? 5-      -   5        $??25??5-      $??25??6$   $??Center=?5.   %   $
??🗇??5/   %   
?????? $??0q?51   %   
???  ??$
??Bold"?53   %   54   %   ?? 56      -   5        $??25??56      $??25??6$   $	??✖??57   %   
?????? $??0q?59   %   
???  ??$
??Bold"?5;   %   5<   %   5=      ?? 5B      -   5         ??Name$ TextBoxLineNumbers??5C      $??1??5B      $??0??6#   $??17(?5C   .    ?? 
IsReadOnly$
 True??6<   $?? ??6N   
???<??
?????? $??0, 20, 0, 20q?6?   $??Right=?6?   $??45??6?   $??Segoe UI)?6?   #  Xceed.Wpf.Toolkit.RichTextBox  5E      -   5          Name$ TextOld??5E   "   " ?? VerticalScrollBarVisibility$ Visible=?6   $
??True??6?   $??1??6?   $??1??6?   	 ?? 
LineHeight$	 1??5F   D   $??17(?6Y   
 ?? AcceptsReturn$

 True??5H   "   $??0, 20, 20, 20q?67      Text 5E   3   ?? *	OldData+ ?? Mode$ TwoWay=? ?? UpdateSourceTrigger$ PropertyChanged=?5I      ?? 5K      -   5        $ TextBoxLineNumbersTwo??5L      $??1??5K      $??2??6#   $??17(?5L   1   $
 True??6?   $?? ??6Q   
???<??
?????? $??0, 20, 0, 20q?6?   $??Right=?6?   $??45??6?   $??Segoe UI)?6?     5N      -   5        $ TextNew??5N   "   $
??True??63   $ Visible=?6X   $??1??6   $??3??6?   $??0, 20, 20, 20q?6?   $	 1??5P   "   $??17(?67   $??1,1,1,1q?5Q   #    5O   "   ?? *	NewData+$ TwoWay=?$ PropertyChanged=?5T      ?? 5X      $ 
Horizontal=?6   $??2??62   $??3??6?   $??Right=?6O   .+?5Y      ?? -   5        $??Сравнить??5Y      $??35,6,3,6q?6,   $	??131??6>   6J   ?? 5Z      -	   5        $??Сохранить??5Z      $??35,6,3,6q?6-   $	??145??6?   6K   5[      ?? 5]      $ 
Horizontal=?6   $??2??62   $??1??6?   $
??Left=?6O   .+?5^      ?? -
   5         ??Name$ Button_download_old??5^      $0??*Загрузить старый текст??66   $??35,6,3,6q?6W   6i   ?? 5_      -   5        $ Button_download_new??5_      $.??(Загрузить новый текст??66   $??35,6,3,6q?6V   6h   5`      5b      5c      5d      