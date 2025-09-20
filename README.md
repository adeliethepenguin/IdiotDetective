# IdiotDetective

Adélie Rosenthal-Wang
100791638

The project is called The Idiot Detective. It's a murder mystery where you gather clues in different rooms and then solve the mystery by selecting a possible suspect when you're done gathering clues. It's a point and click adventure with dialogue.

Below is a diagram showcasing how the game files interact with one another. The player can go to three seperate rooms to gather evidence. The evidence gets logged in a singleton script. The factory stuff isn't in this diagram since it's about the game mechanics interacting with the singleton. The factory stuff is the way I've ordered clues. Evidence is the base class. ItemClue and PersonClue are the subclasses. Item has no dialogue and testimony has dialogue. Both then send their respective clue to the singleton.
![This is a diagram showcasing how the game files interact with one another. The player can go to three seperate rooms to gather evidence. The evidence gets logged in a singleton script. The factory stuff isn't in this diagram since it's about the game mechanics interacting with the singleton. The factory stuff is the way I've ordered clues. Evidence is the base class. ItemClue and PersonClue are the subclasses. Item has no dialogue and testimony has dialogue. Both then send their respective clue to the singleton.](Assets/Sprites/diagram.png "The factory stuff isn't in this diagram since it's about the game mechanics interacting with the singleton. The factory stuff is the way I've ordered clues. Evidence is the base class. ItemEvidence and TestimonyEvidence are the subclasses. Item has no dialogue and testimony has dialogue. Both then send their respective clue to the singleton.")

The singleton is used as a scene manager/dialogue manager/clue keeper. It's referred to by the other scripts in order to switch scenes, display and advance dialogue AND most importantly: keep all clues managed.

Currently I have not yet added the endings so closing the case does nothing
