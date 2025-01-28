namespace Influenceur.Services
{
    public class FileHelper
    {

        /// <summary>
        /// Sauvegarde un fichier uploadé dans un répertoire spécifié et retourne son chemin relatif.
        /// </summary>
        /// <param name="file">Fichier uploadé (IFormFile).</param>
        /// <param name="directoryPath">Chemin relatif du répertoire où sauvegarder le fichier.</param>
        /// <returns>Le chemin relatif du fichier sauvegardé.</returns>
        public static async Task<string> SaveFileAsync(IFormFile file, string directoryPath)
        {
            if (file == null || file.Length == 0)
                throw new ArgumentException("Le fichier est invalide.");

            // Générer un nom unique pour le fichier
            string fileName = Guid.NewGuid().ToString() + Path.GetExtension(file.FileName);

            // Construire le chemin complet pour sauvegarder l'image
            string uploadPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", directoryPath);

            // Créer le dossier s'il n'existe pas
            if (!Directory.Exists(uploadPath))
                Directory.CreateDirectory(uploadPath);

            string filePath = Path.Combine(uploadPath, fileName);

            // Sauvegarder le fichier
            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                await file.CopyToAsync(stream);
            }

            // Retourner le chemin relatif
            return Path.Combine("/", directoryPath, fileName).Replace("\\", "/");
        }
    }
}
