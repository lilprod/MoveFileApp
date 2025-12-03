using System;
using System.IO;

class Program
{
    static void Main(string[] args)
    {
        //string sourceDirectory = @"E:\Prodige\EXTRACT\VOICE_SMS\11"; // Chemin du dossier DATA
        string sourceDirectory = @"E:\Prodige\EXTRACT\DATA\11"; // Chemin du dossier DATA
        string destinationDirectory = @"E:\Prodige\CDR_SOURCES"; // Chemin du dossier CDR_SOURCES

        try
        {
            // Vérifie si le dossier source existe
            if (Directory.Exists(sourceDirectory))
            {
                // Crée le dossier de destination s'il n'existe pas
                if (!Directory.Exists(destinationDirectory))
                {
                    Directory.CreateDirectory(destinationDirectory);
                }

                // Parcours tous les sous-dossiers du dossier source
                string[] subdirectories = Directory.GetDirectories(sourceDirectory, "*", SearchOption.AllDirectories);

                foreach (string subdirectory in subdirectories)
                {
                    // Récupère tous les fichiers dans le sous-dossier
                    string[] files = Directory.GetFiles(subdirectory);

                    foreach (string file in files)
                    {
                        // Détermine le chemin de destination pour chaque fichier
                        string destFile = Path.Combine(destinationDirectory, Path.GetFileName(file));

                        // Copie le fichier dans le dossier de destination
                        File.Copy(file, destFile, overwrite: true); // overwrite: true pour écraser les fichiers existants
                        Console.WriteLine($"Fichier copié : {file} -> {destFile}");
                    }
                }

                Console.WriteLine("Copie terminée !");
            }
            else
            {
                Console.WriteLine($"Le dossier source {sourceDirectory} n'existe pas.");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Une erreur s'est produite : {ex.Message}");
        }
    }
}
