﻿import React, { Component } from 'react'
import { Link } from 'react-router-dom'
import axios from './axios/axios'

class CategoryView extends Component {
    state = {
        search: []
    }
    componentDidMount() {
        this.loadInfo()
    }
    loadInfo = () => {
        const category = this.props.match.params.category
        axios.get(`/api/CategoryView/${category}`).then(resp => {
            this.setState({
                search: resp.data
            })
        })
    }
    render() {
        return (
            <div className="CatView">
                {this.state.search.map(image => {
                    return (
                        <Link
                            key={image.id}
                            to={`/PhotoView/${image.id}`}
                            className="ImageContainer"
                        >
                            <img className="catImage" src={image.imageUrl} />
                            <section className="nameplate">{image.speciesName}</section>
                        </Link>
                    )
                })}
            </div>
        )
    }
}

export default CategoryView
