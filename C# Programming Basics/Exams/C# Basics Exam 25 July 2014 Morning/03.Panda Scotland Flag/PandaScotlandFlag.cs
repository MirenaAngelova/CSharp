using System;
class PandaScotlandFlag
{
    static void Main()
    {
        //Stoyan, a little Panda from Pleven's zoo has a great dream: to visit Scotland someday. 
        //Because of the budget limitations, it is not likely that Stoyan will visit Scotland soon, 
        //and he knows this, so Stoyan is playing every day by trying to draw the flag of Scotland in the sand, 
        //and of course, incorrectly. Once at the zoo a visitor left a tablet in the Stoyan's cage but without Internet. 
        //The only things found in the tablet were Nakov's C# lessons and a carefully installed C# development environment. 
        //Stoyan started learning C# - he has nothing else to do with a tablet without Internet. 
        //Now Stoyan is trying to write a program to print a special version of the Scotland's flag at the console.
        //Help the little Panda Stoyan to write a program that prints at the console the Scotland's flag of size N, 
        //following the examples below.
        //Input
        //The input data should be read from the console. It consists of a single line holding an integer number N – 
        //the size of the flag. The input data will always be valid and in the format described. 
        //There is no need to check it explicitly.
        //Output
        //Print at the console the Scotland's flag (Stoyan's version) like at the examples below.
        //Constraints
        //•	The input number N always will be odd positive integer number [1…501].
        //•	Allowed working time for your program: 0.25 seconds.
        //•	Allowed memory: 16 MB.
        //Examples
        //Input	Output	Input	Output		Input	Output		Input	Output
        //3	    A#B     5	    A###B	    9	    A#######B   21	    A###################B
        //      -C-             ~C#D~               ~C#####D~           ~C#################D~
        //      D#E		        --E--               ~~E###F~~           ~~E###############F~~
        //                      ~F#G~               ~~~G#H~~~           ~~~G#############H~~~
        //                      H###I               ----I----           ~~~~I###########J~~~~	
        //                                          ~~~J#K~~~           ~~~~~K#########L~~~~~
        //                                          ~~L###M~~           ~~~~~~M#######N~~~~~~
        //                                          ~N#####O~           ~~~~~~~O#####P~~~~~~~
        //                                          P#######Q           ~~~~~~~~Q###R~~~~~~~~
        //                                                              ~~~~~~~~~S#T~~~~~~~~~
        //                                                              ----------U----------
        //                                                              ~~~~~~~~~V#W~~~~~~~~~
        //                                                              ~~~~~~~~X###Y~~~~~~~~
        //                                                              ~~~~~~~Z#####A~~~~~~~
        //		                                                        ~~~~~~B#######C~~~~~~
        //                                                              ~~~~~D#########E~~~~~
        //                                                              ~~~~F###########G~~~~
        //                                                              ~~~H#############I~~~
        //                                                              ~~J###############K~~
        //                                                              ~L#################M~
        //                                                              N###################O

        int n = int.Parse(Console.ReadLine());
        char letter = 'A';
        int count = n / 2;
        int midPoint = n / 2;
        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < n; j++)
            {
                if (((j < midPoint - count) | (j > midPoint + count)) & (i > 0))
                {
                    if ((i < midPoint) | (i > midPoint))
                    {
                        Console.Write("~");
                    }
                    else if (i == midPoint)
                    {
                        Console.Write("-");
                    }
                }
                else if (j == midPoint - count)
                {
                    Console.Write(letter);
                    if (letter == 'Z')
                    {
                        letter = 'A';
                    }
                    else
                    {
                        letter++;
                    }
                }
                else if ((j > midPoint - count) & (j < midPoint + count))
                {
                    Console.Write("#");
                }
                else if (j == midPoint + count)
                {
                    Console.Write(letter);
                    if (letter == 'Z')
                    {
                        letter = 'A';
                    }
                    else
                    {
                        letter++;
                    }
                }
            }
            Console.WriteLine();
            if (i < midPoint)
            {
                count--;
            }
            else
            {
                count++;
            }
        }
    }
}
        



