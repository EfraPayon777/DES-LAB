using Microsoft.EntityFrameworkCore;

namespace LibrosAPI.Models
{
    public class LibrosDbContext : DbContext
    {
        public LibrosDbContext(DbContextOptions<LibrosDbContext> options) : base(options)
        {
        }

        public DbSet<Libro> Libros { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // DataSeed: 100 libros
            var libros = new List<Libro>
            {
                new Libro { Id = 1, Titulo = "Cien años de soledad", Autor = "Gabriel García Márquez", AnioPublicacion = 1967 },
                new Libro { Id = 2, Titulo = "Don Quijote de la Mancha", Autor = "Miguel de Cervantes", AnioPublicacion = 1605 },
                new Libro { Id = 3, Titulo = "El amor en los tiempos del cólera", Autor = "Gabriel García Márquez", AnioPublicacion = 1985 },
                new Libro { Id = 4, Titulo = "Ficciones", Autor = "Jorge Luis Borges", AnioPublicacion = 1944 },
                new Libro { Id = 5, Titulo = "El Aleph", Autor = "Jorge Luis Borges", AnioPublicacion = 1949 },
                new Libro { Id = 6, Titulo = "Rayuela", Autor = "Julio Cortázar", AnioPublicacion = 1963 },
                new Libro { Id = 7, Titulo = "La ciudad y los perros", Autor = "Mario Vargas Llosa", AnioPublicacion = 1963 },
                new Libro { Id = 8, Titulo = "Conversación en La Catedral", Autor = "Mario Vargas Llosa", AnioPublicacion = 1969 },
                new Libro { Id = 9, Titulo = "La fiesta del chivo", Autor = "Mario Vargas Llosa", AnioPublicacion = 2000 },
                new Libro { Id = 10, Titulo = "Pedro Páramo", Autor = "Juan Rulfo", AnioPublicacion = 1955 },
                new Libro { Id = 11, Titulo = "El llano en llamas", Autor = "Juan Rulfo", AnioPublicacion = 1953 },
                new Libro { Id = 12, Titulo = "La tregua", Autor = "Mario Benedetti", AnioPublicacion = 1960 },
                new Libro { Id = 13, Titulo = "Gracias por el fuego", Autor = "Mario Benedetti", AnioPublicacion = 1965 },
                new Libro { Id = 14, Titulo = "La casa de los espíritus", Autor = "Isabel Allende", AnioPublicacion = 1982 },
                new Libro { Id = 15, Titulo = "De amor y de sombra", Autor = "Isabel Allende", AnioPublicacion = 1984 },
                new Libro { Id = 16, Titulo = "Eva Luna", Autor = "Isabel Allende", AnioPublicacion = 1987 },
                new Libro { Id = 17, Titulo = "Crónica de una muerte anunciada", Autor = "Gabriel García Márquez", AnioPublicacion = 1981 },
                new Libro { Id = 18, Titulo = "El coronel no tiene quien le escriba", Autor = "Gabriel García Márquez", AnioPublicacion = 1961 },
                new Libro { Id = 19, Titulo = "Los pasos perdidos", Autor = "Alejo Carpentier", AnioPublicacion = 1953 },
                new Libro { Id = 20, Titulo = "El reino de este mundo", Autor = "Alejo Carpentier", AnioPublicacion = 1949 },
                new Libro { Id = 21, Titulo = "Huasipungo", Autor = "Jorge Icaza", AnioPublicacion = 1934 },
                new Libro { Id = 22, Titulo = "Doña Bárbara", Autor = "Rómulo Gallegos", AnioPublicacion = 1929 },
                new Libro { Id = 23, Titulo = "La vorágine", Autor = "José Eustasio Rivera", AnioPublicacion = 1924 },
                new Libro { Id = 24, Titulo = "Señor Presidente", Autor = "Miguel Ángel Asturias", AnioPublicacion = 1946 },
                new Libro { Id = 25, Titulo = "Hombres de maíz", Autor = "Miguel Ángel Asturias", AnioPublicacion = 1949 },
                new Libro { Id = 26, Titulo = "Sobre héroes y tumbas", Autor = "Ernesto Sabato", AnioPublicacion = 1961 },
                new Libro { Id = 27, Titulo = "El túnel", Autor = "Ernesto Sabato", AnioPublicacion = 1948 },
                new Libro { Id = 28, Titulo = "Abaddón el exterminador", Autor = "Ernesto Sabato", AnioPublicacion = 1974 },
                new Libro { Id = 29, Titulo = "Los detectives salvajes", Autor = "Roberto Bolaño", AnioPublicacion = 1998 },
                new Libro { Id = 30, Titulo = "2666", Autor = "Roberto Bolaño", AnioPublicacion = 2004 },
                new Libro { Id = 31, Titulo = "Estrella distante", Autor = "Roberto Bolaño", AnioPublicacion = 1996 },
                new Libro { Id = 32, Titulo = "La muerte de Artemio Cruz", Autor = "Carlos Fuentes", AnioPublicacion = 1962 },
                new Libro { Id = 33, Titulo = "Aura", Autor = "Carlos Fuentes", AnioPublicacion = 1962 },
                new Libro { Id = 34, Titulo = "Terra Nostra", Autor = "Carlos Fuentes", AnioPublicacion = 1975 },
                new Libro { Id = 35, Titulo = "Paradiso", Autor = "José Lezama Lima", AnioPublicacion = 1966 },
                new Libro { Id = 36, Titulo = "Yo el Supremo", Autor = "Augusto Roa Bastos", AnioPublicacion = 1974 },
                new Libro { Id = 37, Titulo = "Hijo de hombre", Autor = "Augusto Roa Bastos", AnioPublicacion = 1960 },
                new Libro { Id = 38, Titulo = "La sombra del viento", Autor = "Carlos Ruiz Zafón", AnioPublicacion = 2001 },
                new Libro { Id = 39, Titulo = "El juego del ángel", Autor = "Carlos Ruiz Zafón", AnioPublicacion = 2008 },
                new Libro { Id = 40, Titulo = "El prisionero del cielo", Autor = "Carlos Ruiz Zafón", AnioPublicacion = 2011 },
                new Libro { Id = 41, Titulo = "El laberinto de los espíritus", Autor = "Carlos Ruiz Zafón", AnioPublicacion = 2016 },
                new Libro { Id = 42, Titulo = "Marina", Autor = "Carlos Ruiz Zafón", AnioPublicacion = 1999 },
                new Libro { Id = 43, Titulo = "Patria", Autor = "Fernando Aramburu", AnioPublicacion = 2016 },
                new Libro { Id = 44, Titulo = "El nombre de la rosa", Autor = "Umberto Eco", AnioPublicacion = 1980 },
                new Libro { Id = 45, Titulo = "El péndulo de Foucault", Autor = "Umberto Eco", AnioPublicacion = 1988 },
                new Libro { Id = 46, Titulo = "1984", Autor = "George Orwell", AnioPublicacion = 1949 },
                new Libro { Id = 47, Titulo = "Rebelión en la granja", Autor = "George Orwell", AnioPublicacion = 1945 },
                new Libro { Id = 48, Titulo = "Un mundo feliz", Autor = "Aldous Huxley", AnioPublicacion = 1932 },
                new Libro { Id = 49, Titulo = "Fahrenheit 451", Autor = "Ray Bradbury", AnioPublicacion = 1953 },
                new Libro { Id = 50, Titulo = "Crónicas marcianas", Autor = "Ray Bradbury", AnioPublicacion = 1950 },
                new Libro { Id = 51, Titulo = "El señor de los anillos: La comunidad del anillo", Autor = "J.R.R. Tolkien", AnioPublicacion = 1954 },
                new Libro { Id = 52, Titulo = "El señor de los anillos: Las dos torres", Autor = "J.R.R. Tolkien", AnioPublicacion = 1954 },
                new Libro { Id = 53, Titulo = "El señor de los anillos: El retorno del rey", Autor = "J.R.R. Tolkien", AnioPublicacion = 1955 },
                new Libro { Id = 54, Titulo = "El Hobbit", Autor = "J.R.R. Tolkien", AnioPublicacion = 1937 },
                new Libro { Id = 55, Titulo = "El Silmarillion", Autor = "J.R.R. Tolkien", AnioPublicacion = 1977 },
                new Libro { Id = 56, Titulo = "Crimen y castigo", Autor = "Fiódor Dostoyevski", AnioPublicacion = 1866 },
                new Libro { Id = 57, Titulo = "Los hermanos Karamázov", Autor = "Fiódor Dostoyevski", AnioPublicacion = 1880 },
                new Libro { Id = 58, Titulo = "El idiota", Autor = "Fiódor Dostoyevski", AnioPublicacion = 1869 },
                new Libro { Id = 59, Titulo = "Guerra y paz", Autor = "León Tolstói", AnioPublicacion = 1869 },
                new Libro { Id = 60, Titulo = "Anna Karénina", Autor = "León Tolstói", AnioPublicacion = 1877 },
                new Libro { Id = 61, Titulo = "Orgullo y prejuicio", Autor = "Jane Austen", AnioPublicacion = 1813 },
                new Libro { Id = 62, Titulo = "Sensatez y sentimientos", Autor = "Jane Austen", AnioPublicacion = 1811 },
                new Libro { Id = 63, Titulo = "Emma", Autor = "Jane Austen", AnioPublicacion = 1815 },
                new Libro { Id = 64, Titulo = "Cumbres Borrascosas", Autor = "Emily Brontë", AnioPublicacion = 1847 },
                new Libro { Id = 65, Titulo = "Jane Eyre", Autor = "Charlotte Brontë", AnioPublicacion = 1847 },
                new Libro { Id = 66, Titulo = "Grandes esperanzas", Autor = "Charles Dickens", AnioPublicacion = 1861 },
                new Libro { Id = 67, Titulo = "Historia de dos ciudades", Autor = "Charles Dickens", AnioPublicacion = 1859 },
                new Libro { Id = 68, Titulo = "Oliver Twist", Autor = "Charles Dickens", AnioPublicacion = 1838 },
                new Libro { Id = 69, Titulo = "Moby Dick", Autor = "Herman Melville", AnioPublicacion = 1851 },
                new Libro { Id = 70, Titulo = "El gran Gatsby", Autor = "F. Scott Fitzgerald", AnioPublicacion = 1925 },
                new Libro { Id = 71, Titulo = "El viejo y el mar", Autor = "Ernest Hemingway", AnioPublicacion = 1952 },
                new Libro { Id = 72, Titulo = "Por quién doblan las campanas", Autor = "Ernest Hemingway", AnioPublicacion = 1940 },
                new Libro { Id = 73, Titulo = "Fiesta", Autor = "Ernest Hemingway", AnioPublicacion = 1926 },
                new Libro { Id = 74, Titulo = "Al este del Edén", Autor = "John Steinbeck", AnioPublicacion = 1952 },
                new Libro { Id = 75, Titulo = "Las uvas de la ira", Autor = "John Steinbeck", AnioPublicacion = 1939 },
                new Libro { Id = 76, Titulo = "De ratones y hombres", Autor = "John Steinbeck", AnioPublicacion = 1937 },
                new Libro { Id = 77, Titulo = "El guardián entre el centeno", Autor = "J.D. Salinger", AnioPublicacion = 1951 },
                new Libro { Id = 78, Titulo = "Matar a un ruiseñor", Autor = "Harper Lee", AnioPublicacion = 1960 },
                new Libro { Id = 79, Titulo = "En busca del tiempo perdido", Autor = "Marcel Proust", AnioPublicacion = 1913 },
                new Libro { Id = 80, Titulo = "El extranjero", Autor = "Albert Camus", AnioPublicacion = 1942 },
                new Libro { Id = 81, Titulo = "La peste", Autor = "Albert Camus", AnioPublicacion = 1947 },
                new Libro { Id = 82, Titulo = "El mito de Sísifo", Autor = "Albert Camus", AnioPublicacion = 1942 },
                new Libro { Id = 83, Titulo = "La metamorfosis", Autor = "Franz Kafka", AnioPublicacion = 1915 },
                new Libro { Id = 84, Titulo = "El proceso", Autor = "Franz Kafka", AnioPublicacion = 1925 },
                new Libro { Id = 85, Titulo = "El castillo", Autor = "Franz Kafka", AnioPublicacion = 1926 },
                new Libro { Id = 86, Titulo = "Ulises", Autor = "James Joyce", AnioPublicacion = 1922 },
                new Libro { Id = 87, Titulo = "Retrato del artista adolescente", Autor = "James Joyce", AnioPublicacion = 1916 },
                new Libro { Id = 88, Titulo = "Dublineses", Autor = "James Joyce", AnioPublicacion = 1914 },
                new Libro { Id = 89, Titulo = "El retrato de Dorian Gray", Autor = "Oscar Wilde", AnioPublicacion = 1890 },
                new Libro { Id = 90, Titulo = "Drácula", Autor = "Bram Stoker", AnioPublicacion = 1897 },
                new Libro { Id = 91, Titulo = "Frankenstein", Autor = "Mary Shelley", AnioPublicacion = 1818 },
                new Libro { Id = 92, Titulo = "Los miserables", Autor = "Victor Hugo", AnioPublicacion = 1862 },
                new Libro { Id = 93, Titulo = "Nuestra Señora de París", Autor = "Victor Hugo", AnioPublicacion = 1831 },
                new Libro { Id = 94, Titulo = "El conde de Montecristo", Autor = "Alexandre Dumas", AnioPublicacion = 1844 },
                new Libro { Id = 95, Titulo = "Los tres mosqueteros", Autor = "Alexandre Dumas", AnioPublicacion = 1844 },
                new Libro { Id = 96, Titulo = "Madame Bovary", Autor = "Gustave Flaubert", AnioPublicacion = 1857 },
                new Libro { Id = 97, Titulo = "La divina comedia", Autor = "Dante Alighieri", AnioPublicacion = 1320 },
                new Libro { Id = 98, Titulo = "El principito", Autor = "Antoine de Saint-Exupéry", AnioPublicacion = 1943 },
                new Libro { Id = 99, Titulo = "Ensayo sobre la ceguera", Autor = "José Saramago", AnioPublicacion = 1995 },
                new Libro { Id = 100, Titulo = "El evangelio según Jesucristo", Autor = "José Saramago", AnioPublicacion = 1991 }
            };

            modelBuilder.Entity<Libro>().HasData(libros);
        }
    }
}
