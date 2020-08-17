# MineSweeper
Mine Sweeper written on C#

  I'm glad to introduce one of my first fun projects. 
  It's a very known game Mine Sweeper, I've created on my own being inspired by posobilty creating games on C#. 
Constraction of this program it's not really complicated, I've used my bacis knowleadge of C# and some grafics
features of WPF C#(Windows Presentation Foundation) witch I googled in Internet. 
   By making this my first step in Game Development, I hope to become a Professional Game Developer :) 
   
                                                                  ``-::/++oooooooo+++/+/::-.```                                        
                                                        `.:/ossssoosooooooooooo++oossoo+oooo+++:-`                            
                                                  .-/ooyssssssyhdmmmmmmmNmmmmmmmNNNNNNNNNNmdhs++++oo+:.`                         
                                             `-/syysssyhhmmNNNmmmmmmNNNNNmmmmmmmmmmNNNNNNNNNNNNNNmmhhssoo+:`                         
                                          ./ssyssydmNNmmNNNmNmmmNmmNNNNNmmNmmmmmmmmmmNmNmNNNNNNNNNNNNNNmhssoo+-`                    
                                      `:oysyyhmmNNNNNNNNNmmmmmmNNNNmmmmmmmmmmmmmmmmmmmmmmmNNNNNNNNNNNNNNNNNmdyso+:.`                  
                                   .+yyssydNNNNNNNNNNNNNmmmmmNNNNNNmmmmmmmmmmmmNNNNmmmmmmmmNNNNNNmmNmNNNNNNNNNNmhso+/.`             
                                ./syyyhmNNNNNNNNNNNNNNNNNmNNNNNNNNNNNmmmmmmmmmmmmmmmmmmmNmmmNNNmmNNNNNNNNNNNNNNNNNmhso+:.`          
                             `:shyhmNNNNNNNNNNNNNNNNNNNNNNNNNNNNNmNNmy/------/ohmmmmmmmmmNmmNNNmmmmNNNNmmNNNNNNNNNNNNmsso/.`           
                           ./yhhdNNmNNNNNNNNNNNNNNNNNNNNNNNNNNNy::hms--.......--/dmh//ymmmmmmNNNNmNNNNNNmmNNNNNNNNNNNNNNdys+-`         
                         -oyyhmNNmNNNNNNNNNNNNNNNNNNNNNNNNNNNNd:---//../+/..::--.oy/.-:ymmmmmmNNNNNNNNNNNmmmNNNNNNNNNNNNNNmyyo:`       
                      `:syhdNNNmNNNmNNNNNNNNNNNNNNNNNNNNNNNNNNNmmddy+-.+s+.:/sy/.-:ohdmmmmmmmmNNNNNNNNNNNNmNNNNNNNNNNNNNNNNNmyso:`     
                     :syhmNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNmmmmmms-..../------hmmNNmmNNmmmmmNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNdsso.    
                   -syhdmmmmmNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNmmmmmmmy/-:---:---:/sdmmmmmmNmmmmmNNNNNNNNNNNNNmNNNNNNNNNNNNNNNNNNdss/`   
                 .+yydmmmmmNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNyso/-:odd.----..sy+::+syhmNmmNmmmNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNhys- 
               `/yyhmmmmmmNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNm/.-.omNNmyyhddhydmmdy/--hNNmNmmmmNNNNNNNNNNNNmNNNNNNNNNNNNNNNNNNNNmyy/` 
             .ohsdmmmmmmNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNhoyNNNNNNmmmmmNNmmmmmo/smmNmmmmmmmNNNNNNNNNNNmmNNNNNNNNNNNNNNNNNNNNNhss.
           :yyhdmmmdmmmNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNmmNmNNNmmmmNmNNNNNNNNNNmmNNNNNNNNNNNNNNNNNNNNNNdsy: 
      	  `+hhdmdmddmmmmmNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNmmNNNNNNNNNNNNNNmmNNNNNNNNNNNNNNNNNNNNNNmyy/`
 	  `shddmmmmmmmmmNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNmNNNmNNNNNNNNNNNNNNNNmmNNNNNNNNNNNNNNNNNNNNNNNNhh+`
 	 .shdmmmmmmmmmmNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNmmNmNNNNNmNNNNNNNNNNNNmmNNNNNNNNNNNNNNNNNNNNNNNNhy+`
  	.yhdmmmmmmmmmmNNNNNNNNNNNNNNNNmNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNmNmNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNh+
	yhdmmmmmmmmmNNNNNNNNNNNNNNNNNNNmNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNmmmNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNmNNNNNNNNNNNNNNNNNNNNNNNNNhy+`
     .yhdmmmmmmNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNmmdddddddddddddmmmNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNyy/      
     .yydmmNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNmmmddhhyyyyyyyyhyyhhyyyyyhhddmmNNNNNNNNNNNNNNNNNNNmmmNNNNNNNNNNNNNNNNNNNNNNNNyh:     
    `shdNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNmdhhyyyyyyyyhhhhhhhhhhhyhyyyyhhyyhhhdmNNNNNNNNNNNNNNNNmmmmmNNNNNNNNNNNNNNNNNNNNNNmys.    
    +hdmNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNmmdhhyyyyyyyyyyyhyyyyyyyyyyyyhhyhyhhhhhhhhhddmNNNNNNNNNNNNNmmNmmmNNNNNNNNNNNNNNNNNNNNNNhs+`   
   -hhmNmNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNmmmNNNNNNNNNNNmdhhyyyyyyyyyyyyyyhhhhhhhhhhhhhhhhhhhhhhhhhhddddddmNNNNNNNNNNNmmNmmmNmNNNNNNNNNNNNNNNNNNNNmso:   
  `symNNNNNmmNNmNNmNNNNNNmmmmmmmmmmmmmmdmmmNNNNNNNNmhhyyyyyyyyyyyyhhhddmmmmmmmmmmmmmmmmmmmdddddddddhddddddmNNNNNNNNNNNNNmNNNNNNNNNNNNNNNNNNNNNNNso+`  
  /yhNNmmmmmmNNNNNNNNNNmmdmmdddmmdddddddmmmNNNNNmdhyyyyyyyyyyhhhdddmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmddddddddmmNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNh+o-  
 `yymmmmmmmmmNNNNNNNNmmmdmmdddddmddddddddmNNNNNdhyyyyyyyyyhhdmmdddmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmmNMNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNm+o-  
 :yhNNmmmmmmmmmmNmmmmmmmmmmmdmddddddddddmNNNNdhyyyyyyyyyhdmmmdhdddmmmmmmmmmmmmmmddddmmmmmmmmmmmmmmmmmmmNmmmmmmNmdyyhhhhhhdddddmmmmmmNNNNNNNNNNNNmoo-  
 ssdNNmmmmmmmmmmmmmmmmmmmmmdmmmdmmdddmmmmmNNmyyyyyyyyhddmmmdysossyyyhhhhhhdmdhhhhhhhddddmmmmmmmmmmmmmmmmNmmddmmdy+.   ``````.......-----::://+++o+o: 
.yommNNmmmmmmmmmmdmmmmmNmmmmmmmdmmmmmmmNNNNmhyyyyyyhdmmmmmhyso++ooo+++oo+/odmh+////+syyyhddmmmmmmmmmmmmmmmmmmmmmmds                     
-ysmmmmNmmmmmmmmmmdmmmdddddddmmmmmNNNNNNNNmhyyyyhdmmmmmmmdysooooo++++////::/hmh/---:/++++oyhddmmmmmmmmmmmmmmmmmmmmy                     
:ysmmNNNNmmmmmmmmddddddddmmmmNNNNNNNNNNmmdhyyyyhmmmmmmmmdysooooo++++/////::-:ymh/--:/::://++osydmmmmmmmmmmmmmmmmmmd                     
+ysmmmNNNNNNmmmmmmmddmmmNNNNNNNNNNmddddddyyyyyhmmmmmmmmmhysoosoo+++++////:-...+dd+-::::://++++oyhdmmmmmmmmmmmmmmmmd                     
+sommmmNNNNNNmmmmmmmNNNNNNmdhs+/mdhddddhyyyyyydmmmmmmmmhyssossooo++++///::-````/ddo:::::///++oosyhdmmmmmmmmmmmmmmh+                     
:s+hmmmmmmNmmmmNNNNNNmdyo/-.   `:/oyyyyyyyyyyhdmmmmmmmdysosssso++++++///:-..```.:hms:::://+++oosshmmmmmmmmmmmmms:`                     
`ooommmmmmNNNNNmdhs+:.`            ```:yyyyyyhdddmmmmmhyssssssoo+++////::--......:ymy/:/+ooooossydmmmmmmmmmmd/.                         
 .oohmNNNdhyo+:-.                     -yyyyhhhyhyhdmdhyyysoooo++++/++++/:-.....--::smhydmmmmmmhsydmmmmmmmmmm/                           
  ./oyys:``                           .yhhhhdhyyyhddysssso+++/////:::/+++/:-.----::/dmhhdmmNNNNhyhmmmmmmmmmh                           
    ```                               .yhhhdmyoyyhdysoosso+///+ooo+ssss+++++::---:oddhhhdmmNNNNNddmmmmmmmmms                           
                                      +yhhhddo+yyhdsossso++//+oss/:hshy:oo++//:::ymddmddmmNNNNNNNNmddmmmmmmd.                           
                                     :yhhhyyy++yhyhssssoo+++///++++oss+/+o/////:/NmmmmmmNNNNNNNNNNd-.-sdmmmm/                           
                                    `yyyyyhyy/:yhyhyssoo+++///////+++++////////:-mmmmNNNNNNNNNNNNN+    -oyyy-
                                    -yyyyyyyy- ohyyysoooo+/::::::::::----://///::smNNNNNNNNNNNNNNd`                                     
                                    /yyyhyyyy. -hyyysoooo+/::-..----...-://///:::/ydmNNNNNNNNNNNmo                                     
                                    +yyyyyyyy` /hyysssooo+//::------:-:///////////+oyhdmmmNNmmNmy-                                     
                                    syyyyyyho `shhysssoooo++//////::::/+//:::::::/+ooo+++oosooymo                                       
                                   `syyyhyyh: -yhhyysssooooo++++////:////////:--:/+++o+///////+hy                                       
                                   .yyyyhyyy` ohhhysssssoooooooo++++/+///////+//+ooooo++++++++o+.                                       
                                   :yyyyyyyo `yyhhhsyssssoooosssoooooooo++//++osssooooooooooss/`                                       
                                   +yyyhyyy: -yyyhhsyysssooooo++///++++++///+++oosssssyyyssss-                                         
                                  `syyyhyys` +yyyhhs+hyyssosso//+o/::::///://+++ooossssssss+`                                           
                                  .yyyhhyy/ .yyyyyhs`ohyyssso+///+///:::/-`.:--::/+so+oss+.                                             
                                  :yyyyyhy` /yyyyyhy``syhyyso++//////::::/:::-:::+soooso-                                               
                                  +yyyhyy+  syyyyyhy  `oyhysso++///////-:://///:/oosss/`                                               
                                  syyyhyy. -yyyyyyhs    :yhyyo+++////::::::::/++oosss:                                                 
                                 `yyyhhyo  oyyyyyhh+     .hyyo+++/+++//:://///+ossys.                                                   
                                 -yyhhhy- `yyyyyyyh:      .shs+////+++ooooooossssys`                                                   
                                `syyhhys  /yyyyyyhh-       .yhs+///////++oooooooys.                                                     
                                +yyhhhy:  syyyyyhhy`        `shso+/////////++ooy+`                                                     
                               -yyyhhys  .yyyyyyhh+           /syssoo+o+++oooss:                                                       
                              `syyhhhy-  :yyyyyhhh.             -::/++++/+++:`                                                         
                              +yyhhhy+   +yyhyyhhs                                                                                     
                             :yyyhhyy.   syyhyhhh:                                                                                     
                            `syyhhhy+   `yyyhhhhs                                                                                       
                            +yyhhhhy`   -yyhhhhy.                                                                                       
                           .oyyhhhd/    oyhhhhh/                                                                                       
                           /shyhhhy    -hhhhhhs`                                                                                       
                          .oyhhhhd-    shhhhhh.                                                                                         
                          /shhhhds    -hhhhhh+                                                                                        
                         `syyyhyh.    oyyyyyy                                                                                          

