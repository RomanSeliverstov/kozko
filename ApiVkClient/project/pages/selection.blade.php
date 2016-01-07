@extends ('index')

@section('selection')

<form action="{{action('HomeController@friends')}}">
	
	<select class="form-control" name="page_id">
	@foreach($friends as $friend)
	<option value="{{$friend->OwnerId}}">{{$friend->OwnerId}}</option>
	@endforeach
	</select>

	
	<button type="submit" class="btn btn-primary" style="width: 300px; margin: 0 auto; display: block; margin-top: 10px;">Проверить друзей</button>
</form>
@stop