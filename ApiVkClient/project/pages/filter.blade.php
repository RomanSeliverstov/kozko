@extends ('weekday')
@extends ('city')
@section('content1')

<form action= "{{action('HomeController@weekday')}}">
 <label class="radio-inline"><input type="radio" name="top" value = "topday" checked>��� �� �������</label>
 <label class="radio-inline"><input type="radio" name="top" value = "topweek" >��� �� ��������� ������</label>
 <button type="submit" class="btn btn-success">Success</button>
</form>

<form action= "{{action('HomeController@city')}}">
  <div class="input-group input-group-sm">
      <span class="input-group-addon"><span class="glyphicon glyphicon-user"></span></span>
      <input name = "city_name" type="text" class="form-control">
    </div>
<button type="submit" class="btn btn-success">Success</button>
@stop