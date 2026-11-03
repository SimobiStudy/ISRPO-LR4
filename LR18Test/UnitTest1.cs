using LR18LIB;

namespace LR18Test
{
    [TestFixture]
    public class OITStudentRepositoryTests
    {
        private const string TestFilePath = "test_students.json";
        private OITStudentRepository _repository;

        [SetUp]
        public void Setup()
        {
            if (File.Exists(TestFilePath))
            {
                File.Delete(TestFilePath);
            }
            _repository = new OITStudentRepository(TestFilePath);
        }

        [Test]
        public void AddStudent_ShouldAddStudentToRepository()
        {
            var expected = new OITStudent
            {
                GroupNumber = "23290907/1094",
                Name = "Иванов Иван Иванович",
                BirthDay = new DateTime(2004, 5, 15),
                Phone = "+7(999)123-45-67"
            };

            _repository.Add(expected);
            var actual = _repository.First();

            Assert.That(actual, Is.EqualTo(expected));
        }

        [Test]
        public void FindFirst_ShouldFindStudentByName()
        {
            var student = new OITStudent
            {
                GroupNumber = "23290907/1094",
                Name = "Петров Петр Петрович",
                BirthDay = new DateTime(2004, 3, 20),
                Phone = "+7(999)987-65-43"
            };

            _repository.Add(student);
            var found = _repository.FindFirst("Петров Петр Петрович");

            Assert.That(found, Is.EqualTo(student));
            Assert.That(found.GroupNumber, Is.EqualTo("23290907/1094"));
            Assert.That(found.Phone, Is.EqualTo("+7(999)987-65-43"));
        }

        [Test]
        public void FindFirst_ShouldReturnNullWhenStudentNotFound()
        {
            var student = new OITStudent
            {
                GroupNumber = "23290907/1094",
                Name = "Сидоров Сидор Сидорович",
                BirthDay = new DateTime(2004, 7, 10),
                Phone = "+7(999)555-55-55"
            };

            _repository.Add(student);
            var notFound = _repository.FindFirst("Несуществующее Имя");

            Assert.That(notFound, Is.Null);
        }

        [Test]
        public void FindAndReplace_ShouldUpdateExistingStudent()
        {
            var student1 = new OITStudent
            {
                GroupNumber = "23290907/1094",
                Name = "Кузнецов Кузьма Кузьмич",
                BirthDay = new DateTime(2004, 1, 25),
                Phone = "+7(999)111-11-11"
            };

            var student2 = new OITStudent
            {
                GroupNumber = "23290907/1093",
                Name = "Кузнецов Кузьма Кузьмич",
                BirthDay = new DateTime(2004, 1, 25),
                Phone = "+7(999)222-22-22"
            };

            _repository.Add(student1);
            _repository.FindAndReplace(student2);

            var updated = _repository.FindFirst("Кузнецов Кузьма Кузьмич");

            Assert.That(updated, Is.Not.Null);
            Assert.That(updated.GroupNumber, Is.EqualTo("23290907/1093"));
            Assert.That(updated.Phone, Is.EqualTo("+7(999)222-22-22"));
        }

        [Test]
        public void Where_ShouldFilterStudentsByPredicate()
        {
            _repository.Add(new OITStudent
            {
                GroupNumber = "23290907/1094",
                Name = "Алексеев Алексей Алексеевич",
                BirthDay = new DateTime(2004, 2, 14),
                Phone = "+7(999)333-33-33"
            });

            _repository.Add(new OITStudent
            {
                GroupNumber = "23290907/1093",
                Name = "Романов Роман Романович",
                BirthDay = new DateTime(2005, 6, 18),
                Phone = "+7(999)444-44-44"
            });

            var filtered = _repository.Where(s => s.GroupNumber == "23290907/1094").ToList();

            Assert.That(filtered.Count, Is.EqualTo(1));
            Assert.That(filtered[0].Name, Is.EqualTo("Алексеев Алексей Алексеевич"));
        }

        [Test]
        public void SerializeAsync_ShouldSaveStudentsToJsonFile()
        {
            var student = new OITStudent
            {
                GroupNumber = "23290907/1094",
                Name = "Морозов Мороз Морозович",
                BirthDay = new DateTime(2004, 12, 31),
                Phone = "+7(999)666-66-66"
            };

            _repository.Add(student);
            _repository.Serialize();

            Assert.That(File.Exists(TestFilePath), Is.True);
        }

        [Test]
        public void DeserializeAsync_ShouldLoadStudentsFromJsonFile()
        {
            var originalStudent = new OITStudent
            {
                GroupNumber = "23290907/1092",
                Name = "Соколов Сокол Соколович",
                BirthDay = new DateTime(2005, 8, 22),
                Phone = "+7(999)777-77-77"
            };

            _repository.Add(originalStudent);
            _repository.Serialize();

            var newRepository = new OITStudentRepository(TestFilePath);
            newRepository.Deserialize();

            var loadedStudent = newRepository.First();

            Assert.That(loadedStudent.Name, Is.EqualTo(originalStudent.Name));
            Assert.That(loadedStudent.GroupNumber, Is.EqualTo(originalStudent.GroupNumber));
            Assert.That(loadedStudent.BirthDay, Is.EqualTo(originalStudent.BirthDay));
            Assert.That(loadedStudent.Phone, Is.EqualTo(originalStudent.Phone));
        }

        [Test]
        public void IndexerGet_ShouldReturnStudentByIndex()
        {
            var student = new OITStudent
            {
                GroupNumber = "23290907/1094",
                Name = "Волков Волк Волкович",
                BirthDay = new DateTime(2004, 4, 10),
                Phone = "+7(999)888-88-88"
            };

            _repository.Add(student);
            var retrieved = _repository[0];

            Assert.That(retrieved, Is.EqualTo(student));
        }

        [Test]
        public void IndexerSet_ShouldUpdateStudentByIndex()
        {
            var student1 = new OITStudent
            {
                GroupNumber = "23290907/1094",
                Name = "Лебедев Лебедь Лебедевич",
                BirthDay = new DateTime(2004, 9, 5),
                Phone = "+7(999)999-99-99"
            };

            var student2 = new OITStudent
            {
                GroupNumber = "23290907/1091",
                Name = "Зайцев Заяц Зайцевич",
                BirthDay = new DateTime(2005, 11, 12),
                Phone = "+7(999)000-00-00"
            };

            _repository.Add(student1);
            _repository[0] = student2;

            Assert.That(_repository[0], Is.EqualTo(student2));
        }

        [Test]
        public void CompareStudents_ByName()
        {
            var student1 = new OITStudent
            {
                GroupNumber = "23290907/1094",
                Name = "Барков Барк Баркович",
                BirthDay = new DateTime(2004, 6, 15),
                Phone = "+7(999)111-11-11"
            };

            var student2 = new OITStudent
            {
                GroupNumber = "23290907/1093",
                Name = "Антонов Антон Антонович",
                BirthDay = new DateTime(2004, 7, 20),
                Phone = "+7(999)222-22-22"
            };

            Assert.That(student1 > student2, Is.True);
            Assert.That(student2 < student1, Is.True);
        }

        [Test]
        public void SortStudents_ByGroup()
        {
            var students = new List<OITStudent>
            {
                new OITStudent { GroupNumber = "23290907/1092", Name = "Иванов Иван", BirthDay = DateTime.Now, Phone = "+71" },
                new OITStudent { GroupNumber = "23290907/1090", Name = "Петров Петр", BirthDay = DateTime.Now, Phone = "+72" },
                new OITStudent { GroupNumber = "23290907/1091", Name = "Сидоров Сидор", BirthDay = DateTime.Now, Phone = "+73" }
            };

            students.Sort(new StudentCompareByGroup());

            Assert.That(students[0].GroupNumber, Is.EqualTo("23290907/1090"));
            Assert.That(students[1].GroupNumber, Is.EqualTo("23290907/1091"));
            Assert.That(students[2].GroupNumber, Is.EqualTo("23290907/1092"));
        }

        [Test]
        public void SortStudents_ByBirthDay()
        {
            var students = new List<OITStudent>
            {
                new OITStudent { GroupNumber = "23290907/1094", Name = "Иванов Иван", BirthDay = new DateTime(2005, 3, 15), Phone = "+71" },
                new OITStudent { GroupNumber = "23290907/1093", Name = "Петров Петр", BirthDay = new DateTime(2004, 1, 10), Phone = "+72" },
                new OITStudent { GroupNumber = "23290907/1092", Name = "Сидоров Сидор", BirthDay = new DateTime(2004, 12, 25), Phone = "+73" }
            };

            students.Sort(new StudentCompareByBirthDay());

            Assert.That(students[0].BirthDay, Is.EqualTo(new DateTime(2004, 1, 10)));
            Assert.That(students[1].BirthDay, Is.EqualTo(new DateTime(2004, 12, 25)));
            Assert.That(students[2].BirthDay, Is.EqualTo(new DateTime(2005, 3, 15)));
        }

        [Test]
        public void SortStudents_ByAge()
        {
            var students = new List<OITStudent>
            {
                new OITStudent { GroupNumber = "23290907/1094", Name = "Иванов Иван", BirthDay = new DateTime(2003, 5, 15), Phone = "+71" },
                new OITStudent { GroupNumber = "23290907/1093", Name = "Петров Петр", BirthDay = new DateTime(2004, 1, 10), Phone = "+72" },
                new OITStudent { GroupNumber = "23290907/1092", Name = "Сидоров Сидор", BirthDay = new DateTime(2005, 12, 25), Phone = "+73" }
            };

            students.Sort(new StudentCompareByAge());

            Assert.That(students[0].BirthDay.Year, Is.EqualTo(2005));
            Assert.That(students[1].BirthDay.Year, Is.EqualTo(2004));
            Assert.That(students[2].BirthDay.Year, Is.EqualTo(2003));
        }

        [TearDown]
        public void Cleanup()
        {
            if (File.Exists(TestFilePath))
            {
                File.Delete(TestFilePath);
            }
        }
    }
}