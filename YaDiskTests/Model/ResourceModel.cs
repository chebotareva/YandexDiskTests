namespace YaDiskTests
{
	public class ResourceModel
	{
		public int size { get; set; } //(integer, optional): <Размер файла>,
		public string public_key { get; set; } //(string, optional): <Ключ опубликованного ресурса>,
		public string sha256 { get; set; } //(string, optional): <SHA256-хэш>,
		public Embedded _embedded { get; set; } //(ResourceList, optional): <Список вложенных ресурсов>,
		public string name { get; set; } //(string): <Имя>,
		public string resource_id { get; set; } //(string, optional): <Идентификатор ресурса>,
		public object custom_properties { get; set; } //(object, optional): <Пользовательские атрибуты ресурса>,
		public string public_url { get; set; } //(string, optional): <Публичный URL>,
		public ShareInfo share { get; set; } //(ShareInfo, optional): <Информация об общей папке>,
		public string modified { get; set; } //(string): <Дата изменения>,
		public string created { get; set; } //(string): <Дата создания>,
		public string md5 { get; set; } //(string, optional): <MD5-хэш>,
		public string path { get; set; } //(string): <Путь к ресурсу>,
		public string media_type { get; set; } //(string, optional): <Определённый Диском тип файла>,
		public string preview { get; set; } //(string, optional): <URL превью файла>,
		public string type { get; set; } //(string): <Тип>,
		public string mime_type { get; set; } //(string, optional): <MIME-тип файла>,
		public long revision { get; set; } //(integer, optional): <Ревизия Диска в которой этот ресурс был изменён последний раз>
	}

		public class Embedded
		{
			public string sort { get; set; } //(string, optional): <Поле, по которому отсортирован список>,
			public Resource[] items { get; set; } //(array[Resource]): <Элементы списка>,
			public int limit { get; set; } //(integer, optional): <Количество элементов на странице>,
			public int offset { get; set; } //(integer, optional): <Смещение от начала списка>,
			public string path { get; set; } //(string): <Путь к ресурсу, для которого построен список>,
			public int total { get; set; } //(integer, optional): <Общее количество элементов в списке>
		}

		public class Resource
		{
			public int size { get; set; } //(integer, optional): <Размер файла>,
			public string public_key { get; set; } //(string, optional): <Ключ опубликованного ресурса>,
			public string sha256 { get; set; } //(string, optional): <SHA256-хэш>,
			
			public Embedded _embedded { get; set; } //(ResourceList, optional): <Список вложенных ресурсов>,
			public string name { get; set; } //(string): <Имя>,
			public string resource_id { get; set; } //(string, optional): <Идентификатор ресурса>,
			public object custom_properties { get; set; } //(object, optional): <Пользовательские атрибуты ресурса>,
			public string public_url { get; set; } //(string, optional): <Публичный URL>,
			public ShareInfo share { get; set; } //(ShareInfo, optional): <Информация об общей папке>,
			public string modified { get; set; } //(string): <Дата изменения>,
			public string created { get; set; } //(string): <Дата создания>,
			public string md5 { get; set; } //(string, optional): <MD5-хэш>,
			public string path { get; set; } //(string): <Путь к ресурсу>,
			public string media_type { get; set; } //(string, optional): <Определённый Диском тип файла>,
			public string preview { get; set; } //(string, optional): <URL превью файла>,
			public string type { get; set; } //(string): <Тип>,
			public string mime_type { get; set; } //(string, optional): <MIME-тип файла>,
			public long revision { get; set; } //(integer, optional): <Ревизия Диска в которой этот ресурс был изменён последний раз>
		}

		public class ShareInfo
		{
			public bool is_root { get; set; } //(boolean, optional): <Признак того, что папка является корневой в группе>,
			public bool is_owned { get; set; } //(boolean, optional): <Признак, что текущий пользователь является владельцем общей папки>,
			public string rights { get; set; } //(string): <Права доступа>
		}

		public class FilesResourceList
		{
			public Resource[] items { get; set; } //(array[Resource]): <Элементы списка>,
			public int limit { get; set; } //(integer, optional): <Количество элементов на странице>,
			public int offset { get; set; } //(integer, optional): <Смещение от начала списка>
		}

		public class LastUploadedResourceList
		{
			public Resource[] items { get; set; } //(array[Resource]): <Элементы списка>,
			public int limit { get; set; } //<Количество элементов на странице>
		}
	}