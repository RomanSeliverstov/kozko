@extends ('index')
@section('content')

<div class="container">
		@yield('selection')
</div>

<div class = "friends-form">
   <table class="table table-condensed">
    <thead>
        <tr>
            <th>ID</th>
            <th>POSTID</th>
            <th>LIKES</th>
            <th>DATE</th>
            <th>TEXT</th>
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