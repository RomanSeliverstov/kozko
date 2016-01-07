<?php
namespace App\Http\Controllers;
use Illuminate\Http\Request;
use App\friend;
use App\Http\Requests;
use App\Http\Controllers\Controller;
use App\friendspost;
use App\link;


class HomeController extends Controller
{
    public function index()
	{
      	$friends=friend::groupBy('friends.OwnerId')->get();
	    return view('index',['friends'=>$friends]);
	}

    public function addfriend()
	{

	$add = link::insert([
	    ['link' => $_GET['page_id_add'], 'param' => $_GET['check']]
	]);
		return view('index');

	}
	
	public function city()
	{
	$friendsposts = friendspost::join('friends', function ($join) { $join->on ('friends.FriendID', '=', 'friendsposts.FriendID')->
		where('friends.City', '=', $_GET['city_name']);})->orderBy('friendsposts.CountLikes', 'desc')->take(10)->get();
	
        return view('pages.city',['friendsposts'=>$friendsposts]);
	}

	public function friends()
	{
	$friends = friend::where('OwnerId', '=', $_GET['page_id'])->get();

	
        return view('pages.friend',['friends'=>$friends]);
	}


	
     public function weekday()
	{
	if ($_GET['top'] == "topweek")
	$friendsposts = friendspost::where('Date', '<=', date('Y-m-d 23:59:59'))-> where('Date', '>=', date('Y-m-d 00:00:00', strtotime("-7 day")))
		->orderBy('friendsposts.CountLikes', 'desc')->take(10)->get();
	else
	$friendsposts = friendspost::where('Date', '>=', date('Y-m-d 00:00:00'))-> where('Date', '<=', date('Y-m-d 23:59:59'))
		->orderBy('friendsposts.CountLikes', 'desc')->take(10)->get();
	
        return view('pages.weekday',['friendsposts'=>$friendsposts]);
	}


}