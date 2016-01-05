<?php

namespace App\Http\Controllers;

use Illuminate\Http\Request;
use App\friend;
use App\Http\Requests;
use App\Http\Controllers\Controller;

class HomeController extends Controller
{
    public function index()
	{
		$friends=friend::all();
	    return view('index',['friends'=>$friends]);
	}
	
	public function city()
	{
	
	$friends = friend::where('City', '=', $_GET['city_name'])->get();
	
    return view('index',['friends'=>$friends]);
	}
}
