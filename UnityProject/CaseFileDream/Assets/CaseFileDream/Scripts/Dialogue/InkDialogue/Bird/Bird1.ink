-> main

=== main ===
Oh it's so awful! I'll never recover!
They're all gone!
Oh... I didn't see you down there
I'd love to talk small one but I'm afraid I'm to busy crying

        +[What's wrong?]
            ->Wrong
            
        +[Ok, have fun]
            ->Bye
            
        
        
=== Bye ===
The bird continues to sob

->END  
        
=== Wrong ===
I lost all my precious babies!
They must have fallen out of my nest when the tree shook earlier
And now they've been scattered around the world!
Oh It's so awful!
        
        +[I'll find your Babies]
            ->Babies
            
        +[So go find them]
            ->FindThem
        

=== Babies ===
Oh that would be wonderful!
If you could bring all my Tree Nuts back I would be ever so grateful!
        +[Wait! Tree Nuts?]
            ->TreeNuts
            
        +[what about the babies?]
            ->WhatAbout


=== FindThem ===
I can't leave the nest
All my tears have made my wings wet
I can't fly!
It's aweful!

->Wrong

=== TreeNuts ===
Yes my Tree Nuts are my babies, they got nocked out of the nest
I was stocking up for the Winter!
The Raccoon told me that Tree Nuts made for good eating in the Winter
If you could bring 4 of my Tree Nuts back that would be wonderful

+[Where are they?]
            ->Where
            
=== Where ===
One of them fell down to the bottom of the treetops
One got carried off to the Pink Garden
One fell into the water and got carried down stream into the Cove
The last one was picked up by the Raccoon, maybe you could get it back from him

->END
=== WhatAbout ===
Yes my Tree Nuts are my babies, they got nocked out of the nest
I was stocking up for the Winter!
The Raccoon told me that Tree Nuts made for good eating in the Winter
If you could bring 4 of my Tree Nuts back that would be wonderful

+[Where are they?]
            ->Where
            
->Where

