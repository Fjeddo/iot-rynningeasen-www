import React from 'react';

class IFrame extends React.Component {
    render() {
        const style = {
            display: 'block',
            border: '1px solid #cccccc',
            marginBottom: '40px'
        };

        return(
            <iframe width={'100%'} height={'400'} style={style} src={this.props.src}/>
        );
    }
}

export default IFrame;