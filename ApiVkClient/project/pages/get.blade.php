@extends ('index')
@section('get')

<select class="form-control" name="parameter">
@foreach($friends as $friend)
<option value="{{$friend->City}}"></option>
@endforeach
</select>
@stop