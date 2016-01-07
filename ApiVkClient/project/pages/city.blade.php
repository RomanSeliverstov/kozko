@extends ('index')
@section('content')

<div class = "friends-form">
<table class="table table-condensed">
    <thead>
        <tr>
            <th>FriendID</th>
            <th>PostID</th>
            <th>CountLikes</th>
            <th>Date</th>
            <th>Text</th>
            <th>FriendID</th>
            <th>FirstName</th>
            <th>SecondName</th>
            <th>City</th>
        </tr>
    </thead>
	 <tbody>
@foreach($friendsposts as $friendspost)

		<tr>
			<td>{{$friendspost->FriendID}}</td>
			<td>{{$friendspost->PostID}}</td>
			<td>{{$friendspost->CountLikes}}</td>
			<td>{{$friendspost->Date}}</td>
			<td>{{$friendspost->Text}}</td>
			<td>{{$friendspost->FriendID}}</td>
			<td>{{$friendspost->FirstName}}</td>
			<td>{{$friendspost->SecondName}}</td>
			<td>{{$friendspost->City}}</td>
			
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