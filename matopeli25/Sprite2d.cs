using Godot;
using System;

public partial class Sprite2d : Sprite2D
{
	 // Jäsenmuuttujat seuraavien Fibonaccin lukujen laskemiseen
    private int previous = 0; // Edellinen luku
    private int current = 1;  // Nykyinen luku
    private int frameCount = 0; // Framen laskuri

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		 // Tulostaa "Hello, World!" konsoliin, kun peli käynnistyy
        GD.Print("Hello, World!");
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		// Lisää framen laskuria
        frameCount++;

        // Tulosta nykyisen framen numero ja Fibonaccin luku
        GD.Print($"Frame {frameCount}: {previous}");

        // Laske seuraava Fibonaccin luku
        int next = previous + current;
        previous = current;
        current = next;
 // Lopeta tulostus, jos nykyinen Fibonaccin luku on vähintään 1000
        if (previous >= 1000)
        {
            GD.Print("Reached Fibonacci number >= 1000. Stopping updates.");
            SetProcess(false); // Poista _Process käytöstä
        }
    }
}

