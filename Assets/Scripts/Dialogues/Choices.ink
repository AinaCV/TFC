VAR mainChoice =""
-> main
=== main ===
Hello
Mmm... Is that...
IS THAT A MOONSTONE??!!
Give it to me, please, and I promise I will give you something as valuable as that little precious stone...    
    * [Here, I don't even want it]
      -> GiveMoonstone
    * [Who are you?]
     I am Drugh, I own a little and moitsy cave nearby.
     If you give that treasure... You are welcome in.
        **[Ok, take it.]
        -> GiveMoonstone
        **[It's really important to me, I'm noy giving it away.]
        -> DintGiveMoonstone
        
=== GiveMoonstone
        Lady, you'll make me cry of happiness!! JAJAJAJA. 
        Bye.
        ->DONE
=== DintGiveMoonstone
        You'll regret this...
        ->DONE
->END