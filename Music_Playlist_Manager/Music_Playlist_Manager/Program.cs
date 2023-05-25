using System;

namespace PlaylistManager
{
    class Song
    {
        private String title;
        public string Title
        {
            set { title = value; }
            get { return title; }
        }
        private string artist;
        public string Artist
        {
            set { artist = value; }
            get { return artist; }
        }
        private Song next;
        public Song Next
        {
            get { return next; }
            set { next = value; }
        }

        public Song(string title, string artist)
        {
            Title = title;
            Artist = artist;
            Next = null;
        }
    }

    class Playlist
    {
        private Song head;
        private int size;

        public Playlist()
        {
            head = null;
            size = 0;
        }

        public void AddSong(string title, string artist)
        {
            Song newSong = new Song(title, artist);

            if (head == null)
            {
                head = newSong;
            }
            else
            {
                Song current = head;
                while (current.Next != null)
                {
                    current = current.Next;
                }
                current.Next = newSong;
            }

            size++;
            Console.WriteLine("Song added: {0} by {1}", title, artist);
        }

        public void RemoveSong(string title)
        {
            Song current = head;
            Song previous = null;

            while (current != null && current.Title != title)
            {
                previous = current;
                current = current.Next;
            }

            if (current == null)
            {
                Console.WriteLine("Song not found: {0}", title);
                return;
            }

            if (previous == null)
            {
                head = current.Next;
            }
            else
            {
                previous.Next = current.Next;
            }

            size--;
            Console.WriteLine("Song removed: {0}", title);
        }

        public void PrintPlaylist()
        {
            if (head == null)
            {
                Console.WriteLine("Playlist is empty.");
                return;
            }

            Song current = head;
            int index = 1;

            while (current != null)
            {
                Console.WriteLine("{0}. {1} by {2}", index, current.Title, current.Artist);
                current = current.Next;
                index++;
            }
        }
        public void SortByTitle()
        {
            if (head == null || head.Next == null)
            {
                return;
            }

            bool swapped;
            do
            {
                swapped = false;
                Song current = head;
                Song previous = null;
                while (current.Next != null)
                {
                    if (string.Compare(current.Title, current.Next.Title) > 0)
                    {
                        Song temp = current.Next;
                        current.Next = temp.Next;
                        temp.Next = current;
                        if (previous == null)
                        {
                            head = temp;
                        }
                        else
                        {
                            previous.Next = temp;
                        }
                        previous = temp;
                        swapped = true;
                    }
                    else
                    {
                        previous = current;
                        current = current.Next;
                    }
                }
            } while (swapped);

            Console.WriteLine("Sorted by Title.");
        }

        public void SortByArtist()
        {
            if (head == null || head.Next == null)
            {
                return;
            }

            bool swapped;
            do
            {
                swapped = false;
                Song current = head;
                Song previous = null;
                while (current.Next != null)
                {
                    if (string.Compare(current.Artist, current.Next.Artist) > 0)
                    {
                        Song temp = current.Next;
                        current.Next = temp.Next;
                        temp.Next = current;
                        if (previous == null)
                        {
                            head = temp;
                        }
                        else
                        {
                            previous.Next = temp;
                        }
                        previous = temp;
                        swapped = true;
                    }
                    else
                    {
                        previous = current;
                        current = current.Next;
                    }
                }
            } while (swapped);

            Console.WriteLine("Sorted by Artist.");
        }

        public int GetSize()
        {
            return size;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Playlist myPlaylist = new Playlist();
            int option=0;

            do
            {
                Console.WriteLine();
                Console.WriteLine("Playlist Manager");
                Console.WriteLine("1. Add Song");
                Console.WriteLine("2. Remove Song");
                Console.WriteLine("3. Print Playlist");
                Console.WriteLine("4. Sort by Title");
                Console.WriteLine("5. Sort by Artist");
                Console.WriteLine("6. Quit");
                Console.Write("Enter option: ");

                try
                {
                    option = int.Parse(Console.ReadLine());
                }
                catch (FormatException)
                {
                    Console.WriteLine("Invalid input. Please enter a number.");
                    continue; // restart the loop
                }

                switch (option)
                {
                    case 1:
                        {
                            string title, artist;
                            Console.Write("Enter song title: ");
                            title = Console.ReadLine();
                            Console.Write("Enter artist name: ");
                            artist = Console.ReadLine();
                            myPlaylist.AddSong(title, artist);
                            break;
                        }
                    case 2:
                        {
                            if (myPlaylist.GetSize() == 0)
                            {
                                Console.WriteLine("Playlist is empty.");
                                break;
                            }

                            string title;
                            Console.Write("Enter song title to remove: ");
                            title = Console.ReadLine();
                            myPlaylist.RemoveSong(title);
                            break;
                        }
                    case 3:
                        {
                            myPlaylist.PrintPlaylist();
                            break;
                        }
                    case 4:
                        {
                            myPlaylist.SortByTitle();
                            Console.WriteLine("Playlist sorted by title.");
                            break;
                        }
                    case 5:
                        {
                            myPlaylist.SortByArtist();
                            Console.WriteLine("Playlist sorted by artist.");
                            break;
                        }
                    case 6:
                        {
                            Console.WriteLine("Exiting program.");
                            break;
                        }
                    default:
                        {
                            Console.WriteLine("Invalid option. Please try again.");
                            break;
                        }
                }
            } while (option != 6);
        }
    }
}
