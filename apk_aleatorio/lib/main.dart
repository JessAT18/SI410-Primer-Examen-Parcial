import 'package:flutter/material.dart';
import 'dart:async';
import 'dart:convert';
import 'package:http/http.dart' as http;
import 'dart:math';
void main() => runApp(MiApp());
//Primer widget inmutable statelessW
class MiApp extends StatelessWidget {
  const MiApp({Key key}) : super(key: key);

  @override
  Widget build(BuildContext context) {
    return MaterialApp(
      title: "Mi App",
      home: Inicio(), //Llamar a funcion mutable
    );
  }
}
//statefulW Funcion/Widget Mutable

class Inicio extends StatefulWidget {
  Inicio({Key key}) : super(key: key);

  @override
  _InicioState createState() => _InicioState();
}

class _InicioState extends State<Inicio> {
  var randomNumber = Random().nextInt(1000);
  Future<String> sendData() async{
    var response = await http.post(
      Uri.https('apidoblejess.azurewebsites.net', '/api/random'),
      headers: <String, String>{
        'Content-Type': 'application/json; charset=UTF-8',
      },
      body: jsonEncode(<String, String>{
        "dateTime": DateTime.now().toIso8601String(),
        "random": randomNumber.toString()
      })
    );
    return response.body;
  }
  @override
  Widget build(BuildContext context) {
    return Scaffold(
      appBar: AppBar(
        title: Text("Mi App Jessica"),
      ),
      body: Center(
        child: new ElevatedButton(
          onPressed: sendData,
          child: new Text("Enviar Numero Random")
        ),
      ),
    );
  }
}