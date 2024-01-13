const data = [
    {id:1,author:'donnayy',text:'so truuu'},
    {id:2,author:'monnayy',text:'so mruuu'},
    {id:1,author:'fonnayy',text:'so fsruuu'},
];

function createRemarkable() {
    var remarkable =
        'undefined' != typeof global && global.Remarkable
            ? global.Remarkable
            : window.Remarkable;

    return new remarkable();
}
class Comment extends React.Component {
    rawMarkup() {
        const md = new Remarkable();
        const rawMarkup = md.render(this.props.children.toString());
        return { __html: rawMarkup };
    }
    render() {
        return (
            <div className="comment">
                <h2 className="commentAuthor">{this.props.author}</h2>
                <span dangerouslySetInnerHTML={this.rawMarkup()}/>
            </div>
        );
    }
}

class CommentBox extends React.Component {
    render() {
        return (
            <div className="commentBox">
                <h1>Comments</h1>
                <CommentList data={this.props.data} />
                <CommentForm />
            </div>
        );
    }
}

class CommentList extends React.Component {
    render() {
        const commentNodes = this.props.data.map(comment => (
            <Comment author={comment.author} key={comment.id}>
                {comment.text}
            </Comment >
        ));
        return <div className="commentList">{commentNodes}</div>;
    }
}

class CommentForm extends React.Component {
    render() {
        return (
            <div className="commentForm">commentForm</div>
        );
    }
}

ReactDOM.render(<CommentBox data={data} />, document.getElementById('content'));