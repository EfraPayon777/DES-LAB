using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace LibrosAPI.Migrations
{
    /// <inheritdoc />
    public partial class Seed100Libros : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Libros",
                keyColumn: "Id",
                keyValue: 1,
                column: "Autor",
                value: "Gabriel García Márquez");

            migrationBuilder.UpdateData(
                table: "Libros",
                keyColumn: "Id",
                keyValue: 3,
                column: "Autor",
                value: "Gabriel García Márquez");

            migrationBuilder.InsertData(
                table: "Libros",
                columns: new[] { "Id", "AnioPublicacion", "Autor", "Titulo" },
                values: new object[,]
                {
                    { 4, 1944, "Jorge Luis Borges", "Ficciones" },
                    { 5, 1949, "Jorge Luis Borges", "El Aleph" },
                    { 6, 1963, "Julio Cortázar", "Rayuela" },
                    { 7, 1963, "Mario Vargas Llosa", "La ciudad y los perros" },
                    { 8, 1969, "Mario Vargas Llosa", "Conversación en La Catedral" },
                    { 9, 2000, "Mario Vargas Llosa", "La fiesta del chivo" },
                    { 10, 1955, "Juan Rulfo", "Pedro Páramo" },
                    { 11, 1953, "Juan Rulfo", "El llano en llamas" },
                    { 12, 1960, "Mario Benedetti", "La tregua" },
                    { 13, 1965, "Mario Benedetti", "Gracias por el fuego" },
                    { 14, 1982, "Isabel Allende", "La casa de los espíritus" },
                    { 15, 1984, "Isabel Allende", "De amor y de sombra" },
                    { 16, 1987, "Isabel Allende", "Eva Luna" },
                    { 17, 1981, "Gabriel García Márquez", "Crónica de una muerte anunciada" },
                    { 18, 1961, "Gabriel García Márquez", "El coronel no tiene quien le escriba" },
                    { 19, 1953, "Alejo Carpentier", "Los pasos perdidos" },
                    { 20, 1949, "Alejo Carpentier", "El reino de este mundo" },
                    { 21, 1934, "Jorge Icaza", "Huasipungo" },
                    { 22, 1929, "Rómulo Gallegos", "Doña Bárbara" },
                    { 23, 1924, "José Eustasio Rivera", "La vorágine" },
                    { 24, 1946, "Miguel Ángel Asturias", "Señor Presidente" },
                    { 25, 1949, "Miguel Ángel Asturias", "Hombres de maíz" },
                    { 26, 1961, "Ernesto Sabato", "Sobre héroes y tumbas" },
                    { 27, 1948, "Ernesto Sabato", "El túnel" },
                    { 28, 1974, "Ernesto Sabato", "Abaddón el exterminador" },
                    { 29, 1998, "Roberto Bolaño", "Los detectives salvajes" },
                    { 30, 2004, "Roberto Bolaño", "2666" },
                    { 31, 1996, "Roberto Bolaño", "Estrella distante" },
                    { 32, 1962, "Carlos Fuentes", "La muerte de Artemio Cruz" },
                    { 33, 1962, "Carlos Fuentes", "Aura" },
                    { 34, 1975, "Carlos Fuentes", "Terra Nostra" },
                    { 35, 1966, "José Lezama Lima", "Paradiso" },
                    { 36, 1974, "Augusto Roa Bastos", "Yo el Supremo" },
                    { 37, 1960, "Augusto Roa Bastos", "Hijo de hombre" },
                    { 38, 2001, "Carlos Ruiz Zafón", "La sombra del viento" },
                    { 39, 2008, "Carlos Ruiz Zafón", "El juego del ángel" },
                    { 40, 2011, "Carlos Ruiz Zafón", "El prisionero del cielo" },
                    { 41, 2016, "Carlos Ruiz Zafón", "El laberinto de los espíritus" },
                    { 42, 1999, "Carlos Ruiz Zafón", "Marina" },
                    { 43, 2016, "Fernando Aramburu", "Patria" },
                    { 44, 1980, "Umberto Eco", "El nombre de la rosa" },
                    { 45, 1988, "Umberto Eco", "El péndulo de Foucault" },
                    { 46, 1949, "George Orwell", "1984" },
                    { 47, 1945, "George Orwell", "Rebelión en la granja" },
                    { 48, 1932, "Aldous Huxley", "Un mundo feliz" },
                    { 49, 1953, "Ray Bradbury", "Fahrenheit 451" },
                    { 50, 1950, "Ray Bradbury", "Crónicas marcianas" },
                    { 51, 1954, "J.R.R. Tolkien", "El señor de los anillos: La comunidad del anillo" },
                    { 52, 1954, "J.R.R. Tolkien", "El señor de los anillos: Las dos torres" },
                    { 53, 1955, "J.R.R. Tolkien", "El señor de los anillos: El retorno del rey" },
                    { 54, 1937, "J.R.R. Tolkien", "El Hobbit" },
                    { 55, 1977, "J.R.R. Tolkien", "El Silmarillion" },
                    { 56, 1866, "Fiódor Dostoyevski", "Crimen y castigo" },
                    { 57, 1880, "Fiódor Dostoyevski", "Los hermanos Karamázov" },
                    { 58, 1869, "Fiódor Dostoyevski", "El idiota" },
                    { 59, 1869, "León Tolstói", "Guerra y paz" },
                    { 60, 1877, "León Tolstói", "Anna Karénina" },
                    { 61, 1813, "Jane Austen", "Orgullo y prejuicio" },
                    { 62, 1811, "Jane Austen", "Sensatez y sentimientos" },
                    { 63, 1815, "Jane Austen", "Emma" },
                    { 64, 1847, "Emily Brontë", "Cumbres Borrascosas" },
                    { 65, 1847, "Charlotte Brontë", "Jane Eyre" },
                    { 66, 1861, "Charles Dickens", "Grandes esperanzas" },
                    { 67, 1859, "Charles Dickens", "Historia de dos ciudades" },
                    { 68, 1838, "Charles Dickens", "Oliver Twist" },
                    { 69, 1851, "Herman Melville", "Moby Dick" },
                    { 70, 1925, "F. Scott Fitzgerald", "El gran Gatsby" },
                    { 71, 1952, "Ernest Hemingway", "El viejo y el mar" },
                    { 72, 1940, "Ernest Hemingway", "Por quién doblan las campanas" },
                    { 73, 1926, "Ernest Hemingway", "Fiesta" },
                    { 74, 1952, "John Steinbeck", "Al este del Edén" },
                    { 75, 1939, "John Steinbeck", "Las uvas de la ira" },
                    { 76, 1937, "John Steinbeck", "De ratones y hombres" },
                    { 77, 1951, "J.D. Salinger", "El guardián entre el centeno" },
                    { 78, 1960, "Harper Lee", "Matar a un ruiseñor" },
                    { 79, 1913, "Marcel Proust", "En busca del tiempo perdido" },
                    { 80, 1942, "Albert Camus", "El extranjero" },
                    { 81, 1947, "Albert Camus", "La peste" },
                    { 82, 1942, "Albert Camus", "El mito de Sísifo" },
                    { 83, 1915, "Franz Kafka", "La metamorfosis" },
                    { 84, 1925, "Franz Kafka", "El proceso" },
                    { 85, 1926, "Franz Kafka", "El castillo" },
                    { 86, 1922, "James Joyce", "Ulises" },
                    { 87, 1916, "James Joyce", "Retrato del artista adolescente" },
                    { 88, 1914, "James Joyce", "Dublineses" },
                    { 89, 1890, "Oscar Wilde", "El retrato de Dorian Gray" },
                    { 90, 1897, "Bram Stoker", "Drácula" },
                    { 91, 1818, "Mary Shelley", "Frankenstein" },
                    { 92, 1862, "Victor Hugo", "Los miserables" },
                    { 93, 1831, "Victor Hugo", "Nuestra Señora de París" },
                    { 94, 1844, "Alexandre Dumas", "El conde de Montecristo" },
                    { 95, 1844, "Alexandre Dumas", "Los tres mosqueteros" },
                    { 96, 1857, "Gustave Flaubert", "Madame Bovary" },
                    { 97, 1320, "Dante Alighieri", "La divina comedia" },
                    { 98, 1943, "Antoine de Saint-Exupéry", "El principito" },
                    { 99, 1995, "José Saramago", "Ensayo sobre la ceguera" },
                    { 100, 1991, "José Saramago", "El evangelio según Jesucristo" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Libros",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Libros",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Libros",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Libros",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Libros",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Libros",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Libros",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Libros",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Libros",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Libros",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Libros",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Libros",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "Libros",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "Libros",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "Libros",
                keyColumn: "Id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "Libros",
                keyColumn: "Id",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "Libros",
                keyColumn: "Id",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "Libros",
                keyColumn: "Id",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "Libros",
                keyColumn: "Id",
                keyValue: 22);

            migrationBuilder.DeleteData(
                table: "Libros",
                keyColumn: "Id",
                keyValue: 23);

            migrationBuilder.DeleteData(
                table: "Libros",
                keyColumn: "Id",
                keyValue: 24);

            migrationBuilder.DeleteData(
                table: "Libros",
                keyColumn: "Id",
                keyValue: 25);

            migrationBuilder.DeleteData(
                table: "Libros",
                keyColumn: "Id",
                keyValue: 26);

            migrationBuilder.DeleteData(
                table: "Libros",
                keyColumn: "Id",
                keyValue: 27);

            migrationBuilder.DeleteData(
                table: "Libros",
                keyColumn: "Id",
                keyValue: 28);

            migrationBuilder.DeleteData(
                table: "Libros",
                keyColumn: "Id",
                keyValue: 29);

            migrationBuilder.DeleteData(
                table: "Libros",
                keyColumn: "Id",
                keyValue: 30);

            migrationBuilder.DeleteData(
                table: "Libros",
                keyColumn: "Id",
                keyValue: 31);

            migrationBuilder.DeleteData(
                table: "Libros",
                keyColumn: "Id",
                keyValue: 32);

            migrationBuilder.DeleteData(
                table: "Libros",
                keyColumn: "Id",
                keyValue: 33);

            migrationBuilder.DeleteData(
                table: "Libros",
                keyColumn: "Id",
                keyValue: 34);

            migrationBuilder.DeleteData(
                table: "Libros",
                keyColumn: "Id",
                keyValue: 35);

            migrationBuilder.DeleteData(
                table: "Libros",
                keyColumn: "Id",
                keyValue: 36);

            migrationBuilder.DeleteData(
                table: "Libros",
                keyColumn: "Id",
                keyValue: 37);

            migrationBuilder.DeleteData(
                table: "Libros",
                keyColumn: "Id",
                keyValue: 38);

            migrationBuilder.DeleteData(
                table: "Libros",
                keyColumn: "Id",
                keyValue: 39);

            migrationBuilder.DeleteData(
                table: "Libros",
                keyColumn: "Id",
                keyValue: 40);

            migrationBuilder.DeleteData(
                table: "Libros",
                keyColumn: "Id",
                keyValue: 41);

            migrationBuilder.DeleteData(
                table: "Libros",
                keyColumn: "Id",
                keyValue: 42);

            migrationBuilder.DeleteData(
                table: "Libros",
                keyColumn: "Id",
                keyValue: 43);

            migrationBuilder.DeleteData(
                table: "Libros",
                keyColumn: "Id",
                keyValue: 44);

            migrationBuilder.DeleteData(
                table: "Libros",
                keyColumn: "Id",
                keyValue: 45);

            migrationBuilder.DeleteData(
                table: "Libros",
                keyColumn: "Id",
                keyValue: 46);

            migrationBuilder.DeleteData(
                table: "Libros",
                keyColumn: "Id",
                keyValue: 47);

            migrationBuilder.DeleteData(
                table: "Libros",
                keyColumn: "Id",
                keyValue: 48);

            migrationBuilder.DeleteData(
                table: "Libros",
                keyColumn: "Id",
                keyValue: 49);

            migrationBuilder.DeleteData(
                table: "Libros",
                keyColumn: "Id",
                keyValue: 50);

            migrationBuilder.DeleteData(
                table: "Libros",
                keyColumn: "Id",
                keyValue: 51);

            migrationBuilder.DeleteData(
                table: "Libros",
                keyColumn: "Id",
                keyValue: 52);

            migrationBuilder.DeleteData(
                table: "Libros",
                keyColumn: "Id",
                keyValue: 53);

            migrationBuilder.DeleteData(
                table: "Libros",
                keyColumn: "Id",
                keyValue: 54);

            migrationBuilder.DeleteData(
                table: "Libros",
                keyColumn: "Id",
                keyValue: 55);

            migrationBuilder.DeleteData(
                table: "Libros",
                keyColumn: "Id",
                keyValue: 56);

            migrationBuilder.DeleteData(
                table: "Libros",
                keyColumn: "Id",
                keyValue: 57);

            migrationBuilder.DeleteData(
                table: "Libros",
                keyColumn: "Id",
                keyValue: 58);

            migrationBuilder.DeleteData(
                table: "Libros",
                keyColumn: "Id",
                keyValue: 59);

            migrationBuilder.DeleteData(
                table: "Libros",
                keyColumn: "Id",
                keyValue: 60);

            migrationBuilder.DeleteData(
                table: "Libros",
                keyColumn: "Id",
                keyValue: 61);

            migrationBuilder.DeleteData(
                table: "Libros",
                keyColumn: "Id",
                keyValue: 62);

            migrationBuilder.DeleteData(
                table: "Libros",
                keyColumn: "Id",
                keyValue: 63);

            migrationBuilder.DeleteData(
                table: "Libros",
                keyColumn: "Id",
                keyValue: 64);

            migrationBuilder.DeleteData(
                table: "Libros",
                keyColumn: "Id",
                keyValue: 65);

            migrationBuilder.DeleteData(
                table: "Libros",
                keyColumn: "Id",
                keyValue: 66);

            migrationBuilder.DeleteData(
                table: "Libros",
                keyColumn: "Id",
                keyValue: 67);

            migrationBuilder.DeleteData(
                table: "Libros",
                keyColumn: "Id",
                keyValue: 68);

            migrationBuilder.DeleteData(
                table: "Libros",
                keyColumn: "Id",
                keyValue: 69);

            migrationBuilder.DeleteData(
                table: "Libros",
                keyColumn: "Id",
                keyValue: 70);

            migrationBuilder.DeleteData(
                table: "Libros",
                keyColumn: "Id",
                keyValue: 71);

            migrationBuilder.DeleteData(
                table: "Libros",
                keyColumn: "Id",
                keyValue: 72);

            migrationBuilder.DeleteData(
                table: "Libros",
                keyColumn: "Id",
                keyValue: 73);

            migrationBuilder.DeleteData(
                table: "Libros",
                keyColumn: "Id",
                keyValue: 74);

            migrationBuilder.DeleteData(
                table: "Libros",
                keyColumn: "Id",
                keyValue: 75);

            migrationBuilder.DeleteData(
                table: "Libros",
                keyColumn: "Id",
                keyValue: 76);

            migrationBuilder.DeleteData(
                table: "Libros",
                keyColumn: "Id",
                keyValue: 77);

            migrationBuilder.DeleteData(
                table: "Libros",
                keyColumn: "Id",
                keyValue: 78);

            migrationBuilder.DeleteData(
                table: "Libros",
                keyColumn: "Id",
                keyValue: 79);

            migrationBuilder.DeleteData(
                table: "Libros",
                keyColumn: "Id",
                keyValue: 80);

            migrationBuilder.DeleteData(
                table: "Libros",
                keyColumn: "Id",
                keyValue: 81);

            migrationBuilder.DeleteData(
                table: "Libros",
                keyColumn: "Id",
                keyValue: 82);

            migrationBuilder.DeleteData(
                table: "Libros",
                keyColumn: "Id",
                keyValue: 83);

            migrationBuilder.DeleteData(
                table: "Libros",
                keyColumn: "Id",
                keyValue: 84);

            migrationBuilder.DeleteData(
                table: "Libros",
                keyColumn: "Id",
                keyValue: 85);

            migrationBuilder.DeleteData(
                table: "Libros",
                keyColumn: "Id",
                keyValue: 86);

            migrationBuilder.DeleteData(
                table: "Libros",
                keyColumn: "Id",
                keyValue: 87);

            migrationBuilder.DeleteData(
                table: "Libros",
                keyColumn: "Id",
                keyValue: 88);

            migrationBuilder.DeleteData(
                table: "Libros",
                keyColumn: "Id",
                keyValue: 89);

            migrationBuilder.DeleteData(
                table: "Libros",
                keyColumn: "Id",
                keyValue: 90);

            migrationBuilder.DeleteData(
                table: "Libros",
                keyColumn: "Id",
                keyValue: 91);

            migrationBuilder.DeleteData(
                table: "Libros",
                keyColumn: "Id",
                keyValue: 92);

            migrationBuilder.DeleteData(
                table: "Libros",
                keyColumn: "Id",
                keyValue: 93);

            migrationBuilder.DeleteData(
                table: "Libros",
                keyColumn: "Id",
                keyValue: 94);

            migrationBuilder.DeleteData(
                table: "Libros",
                keyColumn: "Id",
                keyValue: 95);

            migrationBuilder.DeleteData(
                table: "Libros",
                keyColumn: "Id",
                keyValue: 96);

            migrationBuilder.DeleteData(
                table: "Libros",
                keyColumn: "Id",
                keyValue: 97);

            migrationBuilder.DeleteData(
                table: "Libros",
                keyColumn: "Id",
                keyValue: 98);

            migrationBuilder.DeleteData(
                table: "Libros",
                keyColumn: "Id",
                keyValue: 99);

            migrationBuilder.DeleteData(
                table: "Libros",
                keyColumn: "Id",
                keyValue: 100);

            migrationBuilder.UpdateData(
                table: "Libros",
                keyColumn: "Id",
                keyValue: 1,
                column: "Autor",
                value: "Gabriel García Marquez");

            migrationBuilder.UpdateData(
                table: "Libros",
                keyColumn: "Id",
                keyValue: 3,
                column: "Autor",
                value: "Gabriel García Marquez");
        }
    }
}
