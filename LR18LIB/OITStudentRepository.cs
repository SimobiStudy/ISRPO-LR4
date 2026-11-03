using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace LR18LIB
{
    /// <summary>
    /// Класс для управления коллекцией студентов отделения ОИТ.
    /// Предоставляет функциональность для добавления, поиска, замены и сохранения/загрузки данных студентов в JSON-формате.
    /// Наследует List&lt;OITStudent&gt; и может использоваться в качестве DataSource для элементов управления данными (DataGridView, etc).
    /// </summary>
    public class OITStudentRepository : List<OITStudent>
    {

        private string filePath;

        public OITStudentRepository(string filePath)
        {
            this.filePath = filePath;
            if (File.Exists(filePath))
                Deserialize();
        }

        /// <summary>
        /// Сохраняет студентов в JSON-файл.
        /// </summary>
        public void Serialize()
        {
            using var file = File.Create(filePath);
            JsonSerializer.Serialize(file, this);
        }

        /// <inheritdoc/>
        public new void Clear()
        {
            base.Clear();
            this.Serialize();
        }

        /// <summary>
        /// Асинхронно сохраняет студентов в JSON-файл.
        /// </summary>
        public async Task SerializeAsync()
        {
            using var file = File.Create(filePath);
            await JsonSerializer.SerializeAsync(file, this);
        }

        /// <summary>
        /// Находит первого студента по полному имени.
        /// </summary>
        /// <param name="name">Полное имя студента для поиска.</param>
        /// <returns>Студент, если найден; иначе null.</returns>
        public OITStudent FindFirst(string name)
        {
            return this.FirstOrDefault(s => s.Name == name);
        }

        /// <summary>
        /// Находит студента по имени и заменяет его данные.
        /// </summary>
        /// <param name="student">Студент с новыми данными.</param>
        public void FindAndReplace(OITStudent student)
        {
            var stud = FindFirst(student.Name);
            if (stud != null)
            {
                stud.Phone = student.Phone;
                stud.BirthDay = student.BirthDay;
                stud.GroupNumber = student.GroupNumber;
            }
        }

        /// <summary>
        /// Реализация поиска студентов по полному имени с учетом различных вариантов написания и опечаток.
        /// </summary>
        /// <param name="query">Строка поиска.</param>
        /// <param name="maxResults">Максимальное количество результатов.</param>
        /// <returns>Коллекция студентов, соответствующих условию.</returns>
        public IEnumerable<OITStudent> SearchByFullName(string query, int maxResults = 1, int minScore = -100)
        {

            // (Алгоритм перекопирован с интернета, чтобы был очень крутой поиск)
            if (string.IsNullOrWhiteSpace(query))
            {
                return this;
            }

            static string normalize(string s)
            {
                if (string.IsNullOrWhiteSpace(s)) return string.Empty;
                var parts = s.Trim().ToLowerInvariant().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                return string.Join(' ', parts);
            }

            var q = normalize(query);
            var qParts = q.Split(' ', StringSplitOptions.RemoveEmptyEntries);

            var scored = this.Select(s =>
            {
                var name = normalize(s.Name ?? string.Empty);
                var nameParts = name.Split(' ', StringSplitOptions.RemoveEmptyEntries);
                var score = 0;
                if (name == q) score += 1000;
                foreach (var qp in qParts)
                {
                    var matched = false;
                    foreach (var np in nameParts)
                    {
                        if (np == qp)
                        {
                            score += 50;
                            matched = true;
                            break;
                        }
                        if (np.StartsWith(qp, StringComparison.Ordinal))
                        {
                            score += 30;
                            matched = true;
                            break;
                        }
                        if (qp.Length >= 3 && np.Contains(qp, StringComparison.Ordinal))
                        {
                            score += 10;
                            matched = true;
                            break;
                        }
                    }
                    if (!matched) score -= 20;
                }
                return (student: s, score);
            });

            return scored.Where(x => x.score > minScore).OrderByDescending(x => x.score).ThenBy(x => x.student.Name).Take(maxResults).Select(x => x.student);
        }

        /// <summary>
        /// Реализация поиска студентов по номеру группы с учетом различных вариантов написания и опечаток.
        /// </summary>
        /// <param name="query">Строка поиска.</param>
        /// <param name="maxResults">Максимальное количество результатов.</param>
        /// <param name="minScore">Минимальный балл релевантности.</param>
        /// <returns>Коллекция студентов, соответствующих условию.</returns>
        public IEnumerable<OITStudent> SearchByGroupNumber(string query, int maxResults = 1, int minScore = -100)
        {
            if (string.IsNullOrWhiteSpace(query))
            {
                return this;
            }

            static string normalize(string s)
            {
                if (string.IsNullOrWhiteSpace(s)) return string.Empty;
                var parts = s.Trim().ToLowerInvariant().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                return string.Join(' ', parts);
            }

            var q = normalize(query);
            var qParts = q.Split(' ', StringSplitOptions.RemoveEmptyEntries);

            var scored = this.Select(s =>
            {
                // Алгоритм поиска по номеру группы аналогичен поиску по имени, но с учетом особенностей формата номера группы.
                var group = normalize(s.GroupNumber ?? string.Empty);
                var groupParts = group.Split(' ', StringSplitOptions.RemoveEmptyEntries);
                var score = 0;
                if (group == q) score += 1000;
                foreach (var qp in qParts)
                {
                    var matched = false;
                    foreach (var gp in groupParts)
                    {
                        if (gp == qp)
                        {
                            score += 50;
                            matched = true;
                            break;
                        }
                        if (gp.StartsWith(qp, StringComparison.Ordinal))
                        {
                            score += 30;
                            matched = true;
                            break;
                        }
                        if (qp.Length >= 3 && gp.Contains(qp, StringComparison.Ordinal))
                        {
                            score += 10;
                            matched = true;
                            break;
                        }
                    }
                    if (!matched) score -= 20;
                }
                return (student: s, score);
            });

            return scored.Where(x => x.score > minScore).OrderByDescending(x => x.score).ThenBy(x => x.student.Name).Take(maxResults).Select(x => x.student);
        }

        /// <summary>
        /// Загружает студентов из JSON-файла.
        /// </summary>
        /// <exception cref="FileNotFoundException">Выбрасывается, если файл не найден.</exception>
        public void Deserialize()
        {
            if (!File.Exists(filePath))
            {
                throw new FileNotFoundException("Файл не найден", filePath);
            }

            var loaded = JsonSerializer.Deserialize<List<OITStudent>>(File.ReadAllBytes(filePath));
            this.AddRange(loaded);
        }
        

        /// <summary>
        /// Асинхронно загружает студентов из JSON-файла.
        /// </summary>
        /// <exception cref="FileNotFoundException">Выбрасывается, если файл не найден.</exception>
        public async Task DeserializeAsync()
        {
            if (!File.Exists(filePath))
            {
                throw new FileNotFoundException("Файл не найден", filePath);
            }

            var loaded = await JsonSerializer.DeserializeAsync<List<OITStudent>>(File.OpenRead(filePath));
            this.AddRange(loaded);
        }
    }
}
