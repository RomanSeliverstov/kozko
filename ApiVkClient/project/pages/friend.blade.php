@extends ('index')
@section('content')

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
</div>



<form action= "{{action('HomeController@weekday')}}">
 <label class="radio-inline"><input type="radio" name="top" value = "topday" checked>Топ за сегодня</label>
 <label class="radio-inline"><input type="radio" name="top" value = "topweek" >Топ за прошедшую неделю</label>
 <button type="submit" class="btn btn-success">Success</button>
</form>

<form action= "{{action('HomeController@city')}}">
  <div class="input-group input-group-sm">
      <span class="input-group-addon"><span class="glyphicon glyphicon-user"></span></span>
      <input name = "city_name" type="text" class="form-control">
    </div>
<button type="submit" class="btn btn-success">Success</button>

@stop