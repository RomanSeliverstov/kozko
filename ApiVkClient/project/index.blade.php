<html lang="ru-RU">
<head> 
	<meta charset="UTF-8">
	<title>VkApi</title>
	
	<link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.6/css/bootstrap.min.css" integrity="sha384-1q8mTJOASx8j1Au+a5WDVnPi2lkFfwwEAa8hDDdjZlpLegxhjVME1fgjWPGmkzs7" crossorigin="anonymous">
    <link href="{{ asset('css/home.css') }}" rel="stylesheet" type="text/css" >
	
</head>
<body>

<div class = "friends-form">
<table class="table table-condensed">
    <thead>
        <tr>
            <th>ID</th>
            <th>Имя</th>
            <th>Фамилия</th>
            <th>Город</th>
        </tr>
    </thead>
	 <tbody>
@foreach($friends as $friend)

		<tr>
			<td>{{$friend->FriendID}}</td>
			<td>{{$friend->FirstName}}</td>
			<td>{{$friend->SecondName}}</td>
			<td>{{$friend->City}}</td>
		</tr>

@endforeach
</tbody>
</table>
<form action= "{{action('HomeController@city')}}">
  <div class="input-group input-group-sm">
      <span class="input-group-addon"><span class="glyphicon glyphicon-user"></span></span>
      <input name = "city_name" id = "cityid" type="text" class="form-control">
    </div>
<button type="submit" class="btn btn-success">Success</button>
<script>



  </form>


</div>
</body>
<html>