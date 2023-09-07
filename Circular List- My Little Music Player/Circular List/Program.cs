using System;

public class Song
{
    public string Title { get; set; }
    public string Artist { get; set; }
    // Other song-related properties can be added

    public Song(string title, string artist)
    {
        Title = title;
        Artist = artist;
    }

    public override string ToString()
    {
        return $"{Title} by {Artist}";
    }
}

public class Node
{
    public Song Data { get; set; }
    public Node Next { get; set; }

    public Node(Song song)
    {
        Data = song;
        Next = null;
    }
}

public class CircularPlaylist
{
    private Node Head;
    private Node CurrentSong;

    public CircularPlaylist()
    {
        Head = null;
        CurrentSong = null;
    }

    public void AddSong(Song song)
    {
        Node newNode = new Node(song);
        if (Head == null)
        {
            Head = newNode;
            newNode.Next = Head;
            CurrentSong = Head;
        }
        else
        {
            Node temp = Head;
            while (temp.Next != Head)
            {
                temp = temp.Next;
            }
            temp.Next = newNode;
            newNode.Next = Head;
        }
    }
    // Methods for music player
    public void PlayNextSong()
    {
        if (CurrentSong != null)
        {
            Console.WriteLine("Now playing: " + CurrentSong.Data);
            CurrentSong = CurrentSong.Next;
        }
    }

   
    public void LoopPlaylist(bool enableLooping)
    {
        if (Head != null)
        {
            Node lastNode = Head;
            while (lastNode.Next != Head)
            {
                lastNode = lastNode.Next;
            }
            lastNode.Next = enableLooping ? Head : null;
        }
    }

    public void ShufflePlaylist()
    {
        if (Head != null)
        {
            List<Node> nodeList = new List<Node>();
            Node currentNode = Head;
            do
            {
                nodeList.Add(currentNode);
                currentNode = currentNode.Next;
            } while (currentNode != Head);

            Random random = new Random();
            for (int i = nodeList.Count - 1; i > 0; i--)
            {
                int j = random.Next(i + 1);
                Node temp = nodeList[i];
                nodeList[i] = nodeList[j];
                nodeList[j] = temp;
            }

            Head = nodeList[0];
            Node lastNode = Head;
            for (int i = 1; i < nodeList.Count; i++)
            {
                lastNode.Next = nodeList[i];
                lastNode = nodeList[i];
            }
            lastNode.Next = Head;
            CurrentSong = Head;
        }
    }
    //Navigation methods
    public void MoveToNextSong()
    {
        if (CurrentSong != null)
        {
            CurrentSong = CurrentSong.Next;
            Console.WriteLine("Now playing: " + CurrentSong.Data);
        }
    }

    public void MoveToPreviousSong()
    {
        if (CurrentSong != null)
        {
            Node previousNode = Head;
            while (previousNode.Next != CurrentSong)
            {
                previousNode = previousNode.Next;
            }
            CurrentSong = previousNode;
            Console.WriteLine("Now playing: " + CurrentSong.Data);
        }
    }

}

class Program
{
    static void Main(string[] args)
    {
        CircularPlaylist playlist = new CircularPlaylist();

        // Adding songs to the playlist
        playlist.AddSong(new Song("Song: Shape of You", "Artist : Ed Sheeran"));
        playlist.AddSong(new Song("Song: Hello", "Artist : Adele"));
        playlist.AddSong(new Song("Song: Shake it off", "Artist : Taylor Swift"));
        playlist.AddSong(new Song("Song: Uptown Funk", "Artist : Bruno Mars"));

        // Looping and shuffling the playlist
        playlist.LoopPlaylist(true);
        playlist.ShufflePlaylist();

        // Simulating song playback
        for (int i = 0; i < 5; i++)
        {
            playlist.PlayNextSong();
        }

        // Simulating song navigation
        playlist.MoveToNextSong(); // Play first shuffled song
        playlist.MoveToNextSong(); // Play next shuffled song
        playlist.MoveToPreviousSong(); // Play previous song
        playlist.MoveToNextSong(); // Play next shuffled song
    }
}
