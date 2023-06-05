import React, { useState }  from 'react';

import 'bootstrap/dist/css/bootstrap.min.css';

export default function App() {

    const [soldSeats, setSoldSeats] = useState();

    const handleSubmit = (e) => {
        e.preventDefault();
        const targets = e.target;
        const val = {
            codigoPelicula: targets.codigoPelicula.value,
            titulo: targets.titulo.value,
            clasificacion: targets.clasificacion.value,
            asiento: targets.asiento.value,
        }


        fetch("https://localhost:7267/Ventas", {
            method: "POST",
            body: JSON.stringify(val),
            headers: {
                "Content-Type": "application/json"
            },
        }).then((res) => {
            return res.json();
        }).then((data) => {
            setSoldSeats(data);
            document.getElementById("form").reset();
        });
    }

    if (soldSeats) {
        return <div>
            <h1>Registro de Ventas</h1>
            <p>Se ha registrado la venta de {soldSeats} asientos</p>
        </div>
    }

 
    return (
        <div className="container">
            <div className="row">
                <div className="col-md-6 mx-auto mt-5">
                    <div className="card">
                        <div className="card-header">
                            <h3>Registro de Ventas</h3>
                        </div>
                        <div className="card-body">
                            <form id="form" onSubmit={handleSubmit}>
                                <div className="form-group">
                                    <label htmlFor="codigoPelicula">Codigo Pelicula</label>
                                    <input type="text" name="codigoPelicula" id="codigoPelicula" className="form-control" />
                                </div>
                                <div className="form-group">
                                    <label htmlFor="titulo">Titulo</label>
                                    <input type="text" name="titulo" id="titulo" className="form-control"  />
                                </div>
                                <div className="form-group">
                                    <label htmlFor="clasificacion">Clasificacion</label>
                                    <input type="text" name="clasificacion" id="clasificacion" className="form-control" />
                                </div>
                                <div className="form-group">
                                    <label htmlFor="asiento">Asiento</label>
                                    <input type="text" name="asiento" id="asiento" className="form-control" />  
                         
                                </div>
                                <button type="submit" className="btn btn-primary btn-block mt-5">Enviar</button>
                            </form>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    );
                                    

}