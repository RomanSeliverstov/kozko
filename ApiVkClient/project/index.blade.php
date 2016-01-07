<html lang="ru-RU">
<head> 
	<meta charset="UTF-8">
	<title>VkApi</title>
	
	<link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.6/css/bootstrap.min.css" integrity="sha384-1q8mTJOASx8j1Au+a5WDVnPi2lkFfwwEAa8hDDdjZlpLegxhjVME1fgjWPGmkzs7" crossorigin="anonymous">
    <link href="{{ asset('css/home.css') }}" rel="stylesheet" type="text/css" >
	
</head>
<body>
<form action="{{action('HomeController@friends')}}">


	<input class="form-control" type="text" placeholder="ID страницы" name="page_id">
	<button type="submit" class="btn btn-primary" style="width: 300px; margin: 0 auto; display: block; margin-top: 10px;">Проверить друзей</button>
</form>
<form action="{{action('HomeController@addfriend')}}">


	<input class="form-control" type="text" placeholder="ССылка на страницу" name="page_id_add">
	
 <label class="radio-inline"><input type="radio" name="check" value = "1" checked>Добавлять друзей</label>
 <label class="radio-inline"><input type="radio" name="check" value = "0" >Не добавлять друзей</label>
	<button type="submit" class="btn btn-primary" style="width: 300px; margin: 0 auto; display: block; margin-top: 10px;">Добавить пользователя</button>
</form>

	<div class="container">
		@yield('content')
	</div>
</body>
<html>